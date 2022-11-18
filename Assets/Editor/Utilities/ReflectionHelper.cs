using System;
using System.Reflection;

namespace Editor
{
    //Based on: http://dotnetfollower.com/wordpress/2012/12/c-how-to-set-or-get-value-of-a-private-or-internal-property-through-the-reflection/
    public static class ReflectionHelper
    {
        private static FieldInfo GetPropertyInfo(Type type, string propertyName)
        {
            FieldInfo fieldInfo;
            do
            {
                fieldInfo = type.GetField(propertyName, 
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                type = type.BaseType;
            }
            while (fieldInfo == null && type != null);
            return fieldInfo;
        }

        public static object GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            Type objType = obj.GetType();
            FieldInfo fieldInfo = GetPropertyInfo(objType, propertyName);
            if (fieldInfo == null)
                throw new ArgumentOutOfRangeException(nameof(propertyName), $"Couldn't find property {propertyName} in type {objType.FullName}");
            return fieldInfo.GetValue(obj);
        }

        /*public static void SetPropertyValue(this object obj, string propertyName, object val)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Type objType = obj.GetType();
            PropertyInfo propInfo = GetPropertyInfo(objType, propertyName);
            if (propInfo == null)
                throw new ArgumentOutOfRangeException("propertyName", 
                    string.Format("Couldn't find property {0} in type {1}", propertyName, objType.FullName));
            propInfo.SetValue(obj, val, null);
        }*/
    }
}