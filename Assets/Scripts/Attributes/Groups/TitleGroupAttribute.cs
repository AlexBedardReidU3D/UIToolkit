using System;
using System.Diagnostics;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    [Conditional("UNITY_EDITOR")]
    public class TitleGroupAttribute : GroupBaseAttribute
    {
        private readonly string m_Label;  
        
        public readonly bool noUnderline;  
        
        public TitleGroupAttribute(string path, string label = "", bool dontUnderline = false) : base(path)
        {
            m_Label = label;
            
            noUnderline = dontUnderline;
        }

        public string GetLabel() => string.IsNullOrWhiteSpace(m_Label) ? GetName() : m_Label;
    }
}