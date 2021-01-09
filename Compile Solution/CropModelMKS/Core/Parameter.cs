using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace CropModelMKS
{
    public class Parameter : IParameter
    {
        private Dictionary<string, object> parameters;

        private object Convert(string value, string type, string length)
        {
            if (length == "single")
            {
                if (type == "double")
                {
                    return System.Convert.ToDouble(value);
                }
                else if (type == "float")
                {
                    return System.Convert.ToSingle(value);
                }
                else if (type == "integer")
                {
                    return System.Convert.ToInt64(value);
                }
                else if (type == "string")
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                string[] stringlist = value.Split(' ');
                
                if (type == "double")
                {
                    List<double> array = new List<double>{ };
                    foreach (string item in stringlist)
                    {
                        array.Add(System.Convert.ToDouble(item));
                    }

                    return array.ToArray();
                }
                else if (type == "float")
                {
                    List<float> array = new List<float> { };
                    foreach (string item in stringlist)
                    {
                        if (item == "") { continue; }

                        array.Add(System.Convert.ToSingle(item));
                    }

                    return array.ToArray();
                }
                else if (type == "integer")
                {
                    List<long> array = new List<long> { };
                    foreach (string item in stringlist)
                    {
                        array.Add(System.Convert.ToInt64(item));
                    }

                    return array.ToArray();
                }
                else if (type == "string")
                {
                    List<string> array = new List<string> { };
                    foreach (string item in stringlist)
                    {
                        array.Add(item);
                    }

                    return array.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        public Parameter(XmlDocument doc)
        {
            parameters = new Dictionary<string, object> { };

            foreach (XmlElement item in doc.GetElementsByTagName("Parameter"))
            {
                string type = item.GetAttribute("type");
                string size = item.GetAttribute("size");

                XmlNodeList nodes = item.ChildNodes;
                parameters.Add(nodes[0].InnerText, Convert(nodes[1].InnerText, type, size));
            }
        }

        public void Change(string name, object value)
        {
            parameters[name] = value;
        }

        public object Inquire(string name)
        {
            return parameters[name];
        }
    }
}
