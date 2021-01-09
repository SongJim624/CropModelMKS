using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    readonly struct Label
    {
        public readonly string ProgID;
        public readonly int order;

        public Label(string ProgID, int order = 0)
        {
            this.ProgID = ProgID;
            this.order = order;
        }
    }

    struct Information
    {
        public readonly string location;
        public readonly string language;
        public Parameter parameters;
        public readonly DateTime end;

        public Information(XmlNodeList info)
        {
            language = info[0].InnerText;
            location = info[2].InnerText;
            DateTime.TryParse(info[4].InnerText, out end);

            XmlDocument doc = new XmlDocument();
            doc.Load(info[info.Count - 1].InnerText);

            parameters = new Parameter(doc);
        }

        public void Change(string name, object value)
        {
            parameters.Change(name, value);
        }
    }

    class Segment
    {
        private Dictionary<Label, Information> informations;
        private IComponent component;
        private Dictionary<Label, Information>.Enumerator iterator;

        public Segment(State states, XmlNode information)
        {
            informations = new Dictionary<Label, Information> { };

            Dictionary<string, int> indecies = new Dictionary<string, int>();

            foreach (XmlNode node in information.ChildNodes)
            {
                
                XmlNodeList list = node.ChildNodes;
                string ProgID = list[1].InnerText;

                try
                {
                    indecies[ProgID] += 1;
                }
                catch
                {
                    indecies[ProgID] = 1;
                }

                informations[new Label(ProgID, indecies[ProgID])] =
                    new Information(list);
            }
        }

        private void Factory(string language, IState states, IParameter parameters, string ProgID, string location)
        {
            if (language == "Fortran")
            {
                component = new Component_Fortran(states, parameters, ProgID);
            }
            else if (language == "MATLAB")
            {
                component = new Component_Assembly(states, parameters, ProgID, location);
            }
            else
            {
                component = new Component_COM(states, parameters, ProgID);
            }
        }

        public void Initialize(State states)
        {
            iterator = informations.GetEnumerator();
            iterator.MoveNext();
            Factory(iterator.Current.Value.language, states, iterator.Current.Value.parameters,
                iterator.Current.Key.ProgID, iterator.Current.Value.location);
            states.Replace(iterator.Current.Key.ProgID, component);
        }

        public void Update(State states)
        {
            component.Update(states);

            if (states.now == iterator.Current.Value.end)
            {
                if (!iterator.MoveNext()) { iterator = informations.GetEnumerator(); iterator.MoveNext(); }
                Factory(iterator.Current.Value.language, states, iterator.Current.Value.parameters,
                    iterator.Current.Key.ProgID, iterator.Current.Value.location);
                states.Replace(iterator.Current.Key.ProgID, component);
            }
        }

        public bool Change(string lib, int index, string name, object value)
        {
            try
            {
                informations[new Label(lib, index)].parameters.Change(name, value);
                return true;
            }
            catch(KeyNotFoundException) 
            {
                return false;
            }
        }
    }
}
