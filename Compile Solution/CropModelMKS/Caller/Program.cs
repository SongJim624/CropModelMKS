using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CropModelMKS;

namespace CropModelMKS_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Analyzer analyzer = new Analyzer();
            analyzer.Configurate(@"C:\Users\Song Jim\Documents\CropModelMKS\Projects\Analysis\Test For Analysis.XML");
            analyzer.Analyze();
        }
    }
}
