using System;
using System.Diagnostics;
using System.Linq;

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
        private readonly string m_ParentPath;
        
        public GroupBaseAttribute(string path)
        {
            //m_Label = label;
            m_Path = path;

            var pathSplit = m_Path.Split('/');
            m_Name = pathSplit[pathSplit.Length - 1];

            m_ParentPath = (pathSplit.Length > 1) ? string.Join('/', pathSplit.Take(pathSplit.Length - 1)) : null;
        }
        
        //public string GetLabel() => m_Label;
        public string GetPath() => m_Path;
        public string GetName() => m_Name;
        public string GetParentPath() => m_ParentPath;
    }
}