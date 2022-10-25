using System;
using System.Collections.Generic;
using System.Reflection;

namespace Test003
{
    public class ReflectionClass<T>
    {
        Type type;
        T instance;

        public ReflectionClass(T instance)
        {
            this.instance = instance;
            this.type = instance.GetType();
        }

        public void SetValue(string name, object val)
        {
            List<FieldInfo> fields = GetAllFields(this.type);
            for (int i = 0; i < fields.Count; i++)
            {
                if(fields[i].Name == name)
                {
                    fields[i].SetValue(instance, val);
                }
            }
        }

        public object GetValue(string name)
        {
            object _object = null;
            List<FieldInfo> fields = GetAllFields(this.type);
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].Name == name)
                {
                    _object = fields[i].GetValue(instance);
                }
            }
            return _object;
        }

        public static List<FieldInfo> GetAllFields(System.Type type)
        {
            List<FieldInfo> allFields = new List<FieldInfo>();
            FieldInfo[] fields = type.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                allFields.Add(fields[i]);
            }

            return allFields;
        }
    }
}
