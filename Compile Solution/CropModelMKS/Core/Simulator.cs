using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace CropModelMKS
{
    public class Simulator : ISimulator
    {
        private State states;
        private DateTime begin, end;
        private List<Segment> modules;

        public object Inquire(string name, int index)
        {
            return states.Inquire(name, index);
        }

        public void Simulate(int till = 0)
        {
            TimeSpan interval = till == 0 ? end - begin : new TimeSpan(till, 0, 0, 0);

            //This situation presents the RE - Run situation
            if (states.now == end)
            {
                states.now = begin;
                states.Clean(begin);
            }

            if (states.now == begin)
            {
                foreach (Segment module in modules)
                {
                    module.Initialize(states);
                }
            }

            for (; states.now != end; states.now = states.now.AddDays(1))
            {
                if (states.now - begin == interval)
                {
                    return;
                }

                foreach (Segment module in modules)
                {
                    module.Update(states);
                }
            }
        }

        public void Configurate(string path)
        {
            Check check = new Check(path);
            modules.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode begin_node = doc.SelectSingleNode(@"Configuration/Clock/Begin");
            DateTime.TryParse(begin_node.FirstChild.Value.ToString(), out begin);

            states = new State(check.States(), begin);

            XmlNode end_node = doc.SelectSingleNode(@"Configuration/Clock/End");
            DateTime.TryParse(end_node.FirstChild.Value.ToString(), out end);

            XmlNodeList components = doc.SelectNodes(@"Configuration/Module");

            foreach (XmlNode module in components)
            {
                modules.Add(new Segment(states, module));
            }
        }

        public void Change(string lib_name, int index, string name, object value)
        {
            foreach (Segment module in modules)
            {
                if (module.Change(lib_name, index, name, value)) { return; }
            }
        }

        public Simulator()
        {
            states = null;
            modules = new List<Segment> { };
        }
    }
}
