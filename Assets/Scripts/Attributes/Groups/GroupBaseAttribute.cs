using System;
using System.Diagnostics;

namespace Attributes
{
    //TODO Add HideInInspector
    //TODO Add EnableIf/DisableIf
    //TODO Add EnableInEditor/DisableInEditor
    //TODO Add EnableInPlayMode/DisableInPlaymode
    
    [Conditional("UNITY_EDITOR")]
    public abstract class GroupBaseAttribute : Attribute
    {
        //private readonly string m_Label;  
        private readonly string m_Path;
        private readonly string m_Name;
        
        public GroupBaseAttribute(string path)
        {
            //m_Label = label;
            m_Path = path;

            var pathSplit = m_Path.Split('/');
            m_Name = pathSplit[pathSplit.Length - 1];
        }
        
        //public string GetLabel() => m_Label;
        public string GetPath() => m_Path;
        public string GetName() => m_Name;
    }
}