using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    class Component_COM : IComponent
    {
        private Type lib_type;
        private Object lib_object;

        public Component_COM(IState states, IParameter parameters, string ProgID)
        {
            lib_type = Type.GetTypeFromProgID(ProgID);
            lib_object = Activator.CreateInstance(lib_type);
            lib_type.InvokeMember("Initialize", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { states, parameters });
        }

        public Component_COM(string ProgID, string configuration)
        {
            lib_type = Type.GetTypeFromProgID(ProgID);
            lib_object = Activator.CreateInstance(lib_type);
            lib_type.InvokeMember("Configurate", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { configuration });
        }

        void IComponent.Analyze(Simulator simulator)
        {
            lib_type.InvokeMember("Analyze", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { (object)simulator });
        }

        void IComponent.Inquire(string name, IState states)
        {
            lib_type.InvokeMember("Inquire", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { name, states });
        }

        void IComponent.Update(IState states)
        {
            lib_type.InvokeMember("Update", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { states });
            return;
        }
    }

    class Component_Fortran : IComponent
    {
        private Type type_wrapper;
        private Object object_wrapper;

        private Type type_component;
        private Object object_component;
        public Component_Fortran(IState states, IParameter parameters, string ProgID)
        {
            Type type_parameters = Type.GetTypeFromProgID("CropModelMKS.DataWrapper.ForFortran");
            Object object_parameters = Activator.CreateInstance(type_parameters);
            type_parameters.InvokeMember("Attach", BindingFlags.InvokeMethod, null,
                object_parameters, new object[] { parameters });

            type_component = Type.GetTypeFromProgID(ProgID);
            object_component = Activator.CreateInstance(type_component);

            type_wrapper = Type.GetTypeFromProgID("CropModelMKS.DataWrapper.ForFortran");
            object_wrapper = Activator.CreateInstance(type_wrapper);
            type_wrapper.InvokeMember("Attach", BindingFlags.InvokeMethod, null,
                object_wrapper, new object[] { states });

            type_component.InvokeMember("Initialize", BindingFlags.InvokeMethod, null,
                object_component, new object[] { object_wrapper, object_parameters });
        }

        public Component_Fortran(string ProgID, string configuration)
        {
            type_component = Type.GetTypeFromProgID(ProgID);
            object_component = Activator.CreateInstance(type_component);
            type_component.InvokeMember("Configurate", BindingFlags.InvokeMethod, null,
                object_component, new object[] { configuration });
        }

        void IComponent.Analyze(Simulator simulator)
        {
            Type t_wrapper = Type.GetTypeFromProgID("CropModelMKS.DataWrapper.ForFortran");
            Object wrapper = Activator.CreateInstance(t_wrapper);
            t_wrapper.InvokeMember("Attach", BindingFlags.InvokeMethod, null,
                wrapper, new object[] { simulator });

            type_component.InvokeMember("Analyze", BindingFlags.InvokeMethod, null,
                object_component, new object[] { wrapper });
        }

        void IComponent.Inquire(string name, IState states)
        {
            type_component.InvokeMember("Inquire", BindingFlags.InvokeMethod, null,
                object_component, new object[] { name, states });
        }

        void IComponent.Update(IState states)
        {
            type_component.InvokeMember("Update", BindingFlags.InvokeMethod, null,
                object_component, new object[] { object_wrapper });
        }
    }

    class Component_Assembly : IComponent
    {
        private Type lib_type;
        private object lib_object;

        public Component_Assembly(IState states, IParameter parameters, string ProgID, string location)
        {
            lib_object = Assembly.LoadFrom(location).CreateInstance(ProgID + ".Component");
            lib_type = lib_object.GetType();
            lib_type.InvokeMember("Initialize", BindingFlags.InvokeMethod, null,
                lib_object, new object[] {states, parameters });
        }

        public Component_Assembly(string ProgID, string location, string configuration)
        {
            lib_object = Assembly.LoadFrom(location).CreateInstance(ProgID + ".Component");
            lib_type = lib_object.GetType();
            lib_type.InvokeMember("Configurate", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { configuration });
        }

        void IComponent.Analyze(Simulator simulator)
        {
            lib_type.InvokeMember("Analyze", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { simulator });
        }

        void IComponent.Inquire(string name, IState states)
        {
            lib_type.InvokeMember("Inquire", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { name, states });
        }

        void IComponent.Update(IState states)
        {
            lib_type.InvokeMember("Update", BindingFlags.InvokeMethod, null,
                lib_object, new object[] { states });
        }
    }
}
