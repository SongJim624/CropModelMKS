using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    public class Analyzer
    {
        private Simulator simulator;
        private IComponent algorithm;

        void Factory(XmlNodeList config, string configuration)
        {
            string ProgID = config[0].InnerText;
            string language = config[1].InnerText;
            string location = config[2].InnerText;

            if (language == "Fortran")
            {
                algorithm = new Component_Fortran(ProgID, configuration);
            }
            else if (language == "MATLAB")
            {
                algorithm = new Component_Assembly(ProgID, location, configuration);
            }
            else if (language == "Python")
            {
                algorithm = null;
            }
            else
            {
                algorithm = new Component_COM(ProgID, configuration);
            }
        }

        public Analyzer()
        {
            simulator = new Simulator();
            algorithm = null;
        }

        public void Configurate(string project)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(project);

            simulator.Configurate(doc.GetElementsByTagName("Project")[0].InnerText);
            Factory(doc.GetElementsByTagName("AnalyzerConfiguration")[0].ChildNodes, project);
        }

        public void Analyze()
        {
            algorithm.Analyze(simulator);
        }
    }
}
