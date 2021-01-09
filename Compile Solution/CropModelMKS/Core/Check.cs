using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    public class Check
    {
        private XmlDocument project;
        private readonly string folder;

        public Check(string path)
        {
            project = new XmlDocument();
            project.Load(path);

            folder = @"C:\Users\" + Environment.UserName + @"\Documents\CropModelMKS\Converted\";
        }

        static public string Convert(string file, string ProgID, string language, string location)
        {
            string new_file = @"C:\Users\" + Environment.UserName + @"\Documents\CropModelMKS\Converted\"
                + file.Split('\\').ToArray().Last() + ".XML";
            Wrapper converter = new Wrapper(ProgID, language, location);
            converter.Convert(file, new_file);

            return new_file;
        }

        public XmlDocument Parameters()
        {
            XmlDocument parameters = new XmlDocument();
            XmlElement root = parameters.CreateElement("Collection");
            parameters.AppendChild(root);

            foreach (XmlElement module in project.GetElementsByTagName("Module"))
            {
                XmlElement module_item = parameters.CreateElement("Module");
                module_item.SetAttribute("type", module.GetAttribute("type"));

                foreach (XmlElement library in module.GetElementsByTagName("Library"))
                {
                    XmlDocument des = new XmlDocument();
                    string ProgID = library.GetElementsByTagName("ProgID")[0].InnerText;
                    string description = @"C:\Program Files\CropModelMKS\System\Descriptions\" + ProgID + ".XML";
                    des.Load(description);

                    XmlNode parameter = parameters.ImportNode(des.GetElementsByTagName("Parameters")[0], true);
                    ((XmlElement)parameter).SetAttribute("ProgID", ProgID);
                    module_item.AppendChild(parameter);
                }

                root.AppendChild(module_item);
            }

            return parameters;
        }

        public XmlDocument States()
        {
            Dictionary<string, string> supports = new Dictionary<string, string> { };

            XmlDocument states = new XmlDocument();
            XmlElement root = states.CreateElement("States");
            states.AppendChild(root);

            foreach (XmlElement module in project.GetElementsByTagName("Module"))
            {
                XmlElement states_mod = states.CreateElement("Module");
                states_mod.SetAttribute("type", module.GetAttribute("type"));

                List<string> item_list = new List<string> { };

                foreach (XmlElement lib in module.GetElementsByTagName("Library"))
                {
                    XmlDocument des = new XmlDocument();
                    string ProgID = lib.GetElementsByTagName("ProgID")[0].InnerText;
                    string description = @"C:\Program Files\CropModelMKS\System\Descriptions\" + ProgID + ".XML";
                    des.Load(description);

                    XmlElement state = (XmlElement)des.GetElementsByTagName("States")[0];

                    foreach (XmlElement item in state.GetElementsByTagName("item"))
                    {
                        string item_name = item.GetAttribute("name");

                        if (item_list.Contains(item_name)) { continue; }

                        item_list.Add(item_name);

                        states_mod.AppendChild(states.ImportNode(item, true));
                    }

                    XmlElement support = (XmlElement)des.GetElementsByTagName("Supports")[0];

                    foreach (XmlElement item in support.GetElementsByTagName("item"))
                    {
                        string item_name = item.GetAttribute("name");

                        supports.Add(item_name, ProgID);
                    }
                }

                root.AppendChild(states_mod);
            }

            XmlElement sup = states.CreateElement("Supports");
            root.AppendChild(sup);

            foreach (KeyValuePair<string, string> pair in supports)
            {
                XmlElement item = states.CreateElement("item");

                item.SetAttribute("key", pair.Key);
                item.SetAttribute("value", pair.Value);

                sup.AppendChild(item);
            }
            return states;
        }
    }
}
