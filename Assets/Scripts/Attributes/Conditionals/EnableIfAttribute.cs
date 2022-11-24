using System;
using System.Diagnostics;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]  
    [Conditional("UNITY_EDITOR")]
    public class EnableIfAttribute : ConditionalBaseAttribute
    {
        public readonly string FieldName;
        
        public EnableIfAttribute(in string fieldName)
        {
            FieldName = fieldName;
            
            //TODO Need to add something like this to the generated script
            //TODO Might need to subscribe to some sort of event callback to prompt the update
            /*var field = target.GetType().GetField("thisIsAToggle",
            BindingFlags.Instance | 
            BindingFlags.Public | 
            BindingFlags.NonPublic | 
            BindingFlags.Static);

        myInspector.Q<Toggle>("thisIsAToggle").RegisterCallback();
        SetEnabled(myInspector.Q<TextField>("testField"), (bool)field.GetValue(target), true);*/
        }
    }
}