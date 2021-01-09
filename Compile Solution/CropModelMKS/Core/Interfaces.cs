using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CropModelMKS
{
    public interface IParameter
    {
        object Inquire(string name);
    }

    public interface IState
    {
        object Inquire(string name);
        void Write(string name, object value);
        void Receive(object value);
    }

    public interface ISimulator
    {
        object Inquire(string name, int index = 0);
        void Simulate(int till = 0);
        //        void Configurate(string project);
        void Change(string lib_name, int index, string name, object value);
    }

    public interface IComponent
    {
        //The first two fucntions is used for the crop model components
        void Update(IState states);

        void Inquire(string name, IState states);
        //This is used for the analysis components
        void Analyze(Simulator simulator);
    }
}
