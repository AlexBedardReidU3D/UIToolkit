using System;
using System.Reflection;

namespace Editor.Utilities
{
    public static class MemberInfoExtensions
    {
        public static object GetValue(this MemberInfo memberInfo, object forObject)
        {
            if (memberInfo == null)
                throw new NullReferenceException();
            
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Method:
                    return ((MethodInfo)memberInfo).Invoke(forObject, null);
                default:
                    throw new NotImplementedException();
            }
        } 
    }
}