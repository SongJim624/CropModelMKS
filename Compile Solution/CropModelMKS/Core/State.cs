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
    public class State : IState
    {
        public DateTime now;
        private Dictionary<string, IComponent> libraries;

        private Dictionary<string, List<object>> states;
        private readonly Dictionary<string, string> supports;
        private object receiver;

        public State(XmlDocument doc, DateTime begin)
        {
            now = begin;

            states = new Dictionary<string, List<object>> { };                        
            supports = new Dictionary<string, string> { };
            libraries = new Dictionary<string, IComponent> { };
            receiver = null;

            foreach (XmlElement module in doc.GetElementsByTagName("Module"))
            {
                foreach (XmlElement item in module.GetElementsByTagName("item"))
                {
                    states.Add(item.GetAttribute("name"), new List<object> { });
                }
            }

            foreach (XmlElement sup in doc.GetElementsByTagName("Supports"))
            {
                foreach (XmlElement item in sup.GetElementsByTagName("item"))
                {
                    supports.Add(item.GetAttribute("key"), item.GetAttribute("value"));
                }
            }
        }

        public void Write(string name, object value)
        {
            if (states[name].Count == 0 || states[name].Last() != null)
            {
                states[name].Add(Convert(value));
            }
            else
            {
                states[name][states[name].Count - 1] = Convert(value);
            }
        }

        private void Align()
        {
            int size = 0;

            foreach (List<object> list in states.Values)
            {
                size = Math.Max(size, list.Count);
            }

            foreach (List<object> list in states.Values)
            {
                int count = list.Count;

                if (count < size)
                {
                    for (int i = count; i < size; ++i)
                    {
                        list.Add(null);
                    }
                }
            }
        }

        //This inquiry is for the simulator
        public object Inquire(string name, int index)
        {
            try
            {
                return index == 0 ? states[name].Last() : states[name][index - 1];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public void Clean(DateTime begin)
        {
            now = begin;
            foreach (List<object> list in states.Values)
            {
                list.Clear();
            }
        }

        public void Replace(string name, IComponent component)
        {
            if (libraries.Count == 4)
            {
                Align();
            }

            try
            {
                libraries[name] = component;
            }
            catch (KeyNotFoundException)
            {
                libraries.Add(name, component);
            }
        }

        private object Convert(object value)
        {
            if (value.GetType() == typeof(Object[]))
            {
                object[] objects = (object[])value;

                if (objects[0].GetType() == typeof(double))
                {
                    List<double> array = new List<double> { };

                    for (int i = 0; i < objects.Length; ++i)
                    {
                        array.Add((double)objects[i]);
                    }

                    return array.ToArray();
                }
                else if (objects[0].GetType() == typeof(float))
                {
                    List<float> array = new List<float> { };

                    for (int i = 0; i < objects.Length; ++i)
                    {
                        array.Add((float)objects[i]);
                    }

                    return array.ToArray();
                }
                else if (objects[0].GetType() == typeof(int))
                {
                    List<int> array = new List<int> { };

                    for (int i = 0; i < objects.Length; ++i)
                    {
                        array.Add((int)objects[i]);
                    }

                    return array.ToArray();
                }
            }

            return value;
        }

        public object Inquire(string name)
        {
            if (name == "year")
            {
                return now.Year;
            }
            else if (name == "month")
            {
                return now.Month;
            }
            else if (name == "day")
            {
                return now.Day;
            }

            try
            {
                return states[name].Last();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (KeyNotFoundException)
            {
                receiver = null;

                try
                {
                    libraries[supports[name]].Inquire(name, this);
                    return receiver;
                }
                catch (KeyNotFoundException)
                {
                    return null;
                }
            }
        }

        public void Receive(object value)
        {
            receiver = Convert(value);
        }
    }
}
