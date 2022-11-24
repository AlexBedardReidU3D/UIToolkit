using System;
using System.Diagnostics;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    [Conditional("UNITY_EDITOR")]
    public class FoldoutGroupAttribute : GroupBaseAttribute
    {
        private readonly string m_Label;  
        
        public FoldoutGroupAttribute(string path, string label = "") : base(path)
        {
            m_Label = label;
        }

        public string GetLabel() => string.IsNullOrWhiteSpace(m_Label) ? GetName() : m_Label;
    }
}