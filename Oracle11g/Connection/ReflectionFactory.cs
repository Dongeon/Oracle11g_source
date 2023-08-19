using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;


namespace Oracle11g.Connection
{
    public class ReflectionFactory
    {
        private static object _syncRoot = new Object();

        private static ReflectionFactory _instance;



        public static ReflectionFactory GetInstance()

        {

            lock (_syncRoot)

            {

                if (_instance == null)

                {

                    _instance = new ReflectionFactory();

                }



                return _instance;

            }

        }



        public Assembly GetAssembly(Form form)

        {

            if (form == null)

                return null;



            return form.GetType().Assembly;

        }



        //

        public string GetAssemblyName(Form form)

        {

            Assembly assembly = GetAssembly(form);

            if (assembly == null)

                return string.Empty;



            return assembly.FullName;

        }



        public string GetAssemblyName(Type type)

        {

            Assembly assembly = type.Assembly;

            if (assembly == null)

                return string.Empty;



            return assembly.GetName().Name;

        }



        //

        public string GetAssemblyFullName(Type type)

        {

            if (type == null)

                return string.Empty;



            return type.Assembly.FullName;

        }



        //

        public string GetTypeName(Type type)

        {

            return type.Name;

        }



        //

        public Dictionary<string, Type> GetInterfaces(Type interfaceType, Assembly assembly)

        {

            if (assembly == null)

                return new Dictionary<string, Type>();



            Dictionary<string, Type> list = new Dictionary<string, Type>();

            foreach (Type item in assembly.GetTypes())

                if (item.GetInterface(interfaceType.Name) != null)

                    list.Add(item.Name, item);



            return list;

        }



        //

        public Dictionary<string, Type> GetSubclasses(Type type, Assembly assembly)

        {

            if (assembly == null)

                return new Dictionary<string, Type>();



            Dictionary<string, Type> list = new Dictionary<string, Type>();

            foreach (Type item in assembly.GetTypes())

                if (item.IsSubclassOf(type) == true)

                    list.Add(item.Name, item);



            return list;

        }



        public Dictionary<string, Type> GetSubclasses(Type type, string dirName, string fileName)

        {

            string assemblyFile = string.Format(@"{0}\{1}", dirName, fileName);

            Assembly assembly = Assembly.LoadFrom(assemblyFile);



            return GetSubclasses(type, assembly);

        }



        //

        public int CountSubclasses(Type type, Assembly assembly)

        {

            if (assembly == null)

                return 0;



            int count = 0;

            foreach (Type item in assembly.GetTypes())

                if (item.IsSubclassOf(type) == true)

                    count++;



            return count;

        }



        //

        public Assembly LoadAssembly(string assemblyString)

        {

            if (string.IsNullOrEmpty(assemblyString) == true)

                throw new ArgumentNullException();



            return Assembly.Load(assemblyString);

        }



        public Assembly LoadAssembly(AssemblyName assemblyRef)

        {

            if (assemblyRef == null)

                throw new ArgumentNullException();



            return Assembly.Load(assemblyRef);

        }



        //

        public object CreateInstance(Assembly assembly, string typeName)

        {

            if (assembly == null || string.IsNullOrEmpty(typeName) == true)

                throw new ArgumentNullException();



            return assembly.CreateInstance(typeName);

        }



        public object CreateInstance(Assembly assembly, Type type)

        {

            if (assembly == null || type == null)

                throw new ArgumentNullException();



            string typeName = type.FullName;



            return CreateInstance(assembly, typeName);

        }



        public object CreateInstance(string assemblyString, string typeName)

        {

            Assembly assembly = LoadAssembly(assemblyString);



            return CreateInstance(assembly, typeName);

        }



        public object CreateInstance(AssemblyName assemblyRef, string typeName)

        {

            Assembly assembly = LoadAssembly(assemblyRef);



            return CreateInstance(assembly, typeName);

        }



        public object CreateInstance(Type type)

        {

            if (type == null)

                throw new ArgumentNullException();



            return CreateInstance(type.Assembly, type);

        }



        //

        public Dictionary<string, PropertyInfo> GetPropertyInfos(Type type)

        {

            Dictionary<string, PropertyInfo> list = new Dictionary<string, PropertyInfo>();



            foreach (PropertyInfo propertyInfo in type.GetProperties())

                list.Add(propertyInfo.Name, propertyInfo);



            return list;

        }



        public PropertyInfo GetPropertyInfo(Type type, string name)

        {

            if (type == null)

                return null;



            foreach (PropertyInfo propertyInfo in type.GetProperties())

                if (String.Compare(name, propertyInfo.Name, true) == 0)

                    return propertyInfo;



            return null;

        }



        public bool HasPropertyInfo(object obj, string name)

        {

            if (obj == null)

                return false;



            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())

                if (String.Compare(name, propertyInfo.Name, true) == 0)

                    return true;



            return false;

        }



        public Dictionary<string, object> GetPropertyValues(object obj)

        {

            Dictionary<string, object> propertyValues = new Dictionary<string, object>();



            if (obj == null)

                return propertyValues;



            Dictionary<string, PropertyInfo> propertyInfos = GetPropertyInfos(obj.GetType());

            foreach (PropertyInfo propertyInfo in propertyInfos.Values)

            {

                object value = propertyInfo.GetValue(obj, null);



                propertyValues.Add(propertyInfo.Name, value);

            }



            return propertyValues;

        }



        public object GetPropertyValue(object obj, string name)

        {

            if (obj == null)

                return null;



            PropertyInfo propertyInfo = GetPropertyInfo(obj.GetType(), name);



            if (propertyInfo != null)

                return propertyInfo.GetValue(obj, null);



            return null;

        }



        public void SetPropertyValue(object obj, string name, object value)

        {

            if (obj == null)

                return;



            if (string.IsNullOrEmpty(name))

                return;



            PropertyInfo propertyInfo = GetPropertyInfo(obj.GetType(), name);

            if (propertyInfo != null)

                propertyInfo.SetValue(obj, value, null);

        }



        //

        public string GetControlName(Control control)

        {

            if (control == null)

                return string.Empty;



            return control.Name;

        }



        public string GetControlText(Control control)

        {

            if (control == null)

                return string.Empty;



            return control.Text;

        }



        public Assembly GetAssembly(Control control)

        {

            Form form = GetForm(control);

            if (form == null)

                return null;



            return GetAssembly(form);

        }



        public string GetAssemblyName(Control control)

        {

            Assembly assembly = GetAssembly(control);

            if (assembly == null)

                return string.Empty;



            return assembly.GetName().Name;

        }



        public Form GetForm(Control control)

        {

            if (control == null)

                return null;



            return control.FindForm();

        }



        public string GetFormName(Control control)

        {

            Form form = GetForm(control);

            if (form == null)

                return string.Empty;



            return form.Name;

        }



        //public T CreateService<T>(Type defaultType) where T : class

        //{

        //    T instance = default(T);

        //    string typeName = typeof(T).FullName;



        //    try

        //    {
        //        ApplicationContext context = ContextRegistry.GetContext();

        //        instance = (T)context.GetObject(typeName);

        //    }

        //    catch (Exception e)

        //    {

        //        Debug.Print(e.Message);

        //    }



        //    if (instance == null && defaultType != null)

        //        instance = (T)CreateInstance(defaultType);



        //    return instance;

        //}
    }
}
