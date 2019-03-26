using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bonus630.vsta.FacaCaixaAuto
{
    class FacaManager
    {

        private List<Type> typeCorrects;
        private IFaca objIFaca;

        public FacaManager()
        {
            typeCorrects = new List<Type>();
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                if (typeof(IFaca).IsAssignableFrom(type) && !type.IsInterface)
                {
                    typeCorrects.Add(type);
                }
            }
        }
        public Dictionary<string, bool> ListaClass()
        {
            Dictionary<string, bool> lista = new Dictionary<string, bool>();
            foreach (Type type in typeCorrects)
            {
                FieldInfo fieldInfoName = type.GetField("name");
                FieldInfo fieldInfoSimetric = type.GetField("simetric");
                lista.Add(fieldInfoName.GetValue(new object()).ToString(), (bool)fieldInfoSimetric.GetValue(new object()));
            }
            return lista;
        }
        private IFaca generateNewInstance(string nameClass)
        {
            foreach (Type type in typeCorrects)
            {
                if (nameClass == type.GetField("name").GetValue(new object()).ToString())
                {
                    objIFaca = Activator.CreateInstance(type) as IFaca;
                    return objIFaca;
                   
                }

            }
            return null;
        }
        public IFaca inicialize(string nameClass)
        {
            return generateNewInstance(nameClass);
            
        }
        public string version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
