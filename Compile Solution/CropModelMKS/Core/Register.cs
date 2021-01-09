using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using Microsoft.Win32;

namespace CropModelMKS
{
    public class Register
    {
        private readonly string registration_path, description_path;
        private readonly string[] type_list = { "climate", "plant", "environment", "management", "analysis" };

        private void Execute(string strCmd)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardOutput = false,
                CreateNoWindow = false,
                Arguments = "/c " + strCmd
            };

            Process myProcess = new Process()
            {
                StartInfo = processStartInfo
            };

            myProcess.Start();
            myProcess.WaitForExit();
            myProcess.Close();
        }

        public Register()
        {
            registration_path = @"C:\Program Files\CropModelMKS\System\Registrations\";
            description_path = @"C:\Program Files\CropModelMKS\System\Descriptions\";
        }

        public void Add(string type, string language, string location, string ProgID)
        {
            XmlDocument doc = new XmlDocument();
            string path = registration_path + type + ".XML";

            doc.Load(path);

            foreach (XmlElement item in doc.GetElementsByTagName("ProgID"))
            {
                if (item.InnerText == ProgID) { return; }
            }

            XmlElement component = doc.CreateElement("Component");
            doc.DocumentElement.AppendChild(component);

            XmlElement pro = doc.CreateElement("ProgID");
            Console.WriteLine(ProgID);

            pro.InnerText = ProgID;
            component.AppendChild(pro);

            XmlElement lan = doc.CreateElement("language");
            lan.InnerText = language;
            component.AppendChild(lan);

            XmlElement loc = doc.CreateElement("location");
            loc.InnerText = location;
            component.AppendChild(loc);

            if (language != "MATLAB")

            {
                // -s regsvr32 running silenctly, 
                // No notice windiws when successfully reigstered / unregistered dll
                string regsvr32 = "regsvr32 -s {0}";
                string strcmd = string.Format(regsvr32, "\"" + location + "\"");
                Execute(strcmd);
            }

            doc.Save(path);

            Wrapper wrapper = new Wrapper(ProgID, language, location);
            wrapper.Describe(description_path + ProgID + ".XML");
        }

        public void Check()
        {
            XmlDocument doc = new XmlDocument();
            foreach (string type in type_list)
            {
                string path = registration_path + type + ".XML";
                doc.Load(path);

                //file the libraries not exists!
                foreach (XmlElement location in doc.GetElementsByTagName("location"))
                {
                    if (!File.Exists(location.InnerText))
                    {
                        doc.DocumentElement.RemoveChild(location.ParentNode);
                    }
                }

                //find the libraries duplicates
                List<string> name_list = new List<string> { };
                foreach (XmlElement ProgID in doc.GetElementsByTagName("ProgID"))
                {
                    if (name_list.Exists(name => name == ProgID.InnerText))
                    {
                        doc.DocumentElement.RemoveChild(ProgID.ParentNode);
                    }
                    else 
                    {
                        name_list.Add(ProgID.InnerText);
                    }
                }

                doc.Save(path);
            }
        }

        public void Update()
        {
            XmlDocument doc = new XmlDocument();

            foreach (string type in type_list)
            {
                doc.Load(@"C:\Program Files\CropModelMKS\System\Registrations\" + type + ".XML");

                //Update the Descriptions
                foreach (XmlElement ProgID in doc.GetElementsByTagName("Component"))
                {
                    Wrapper wrapper = new Wrapper(ProgID.ChildNodes[0].InnerText,
                        ProgID.ChildNodes[1].InnerText, ProgID.ChildNodes[2].InnerText);

                    wrapper.Describe(@"C:\Program Files\CropModelMKS\System\Descriptions\" + ProgID.ChildNodes[0].InnerText + ".XML");
                }
            }
        }
    }
}
