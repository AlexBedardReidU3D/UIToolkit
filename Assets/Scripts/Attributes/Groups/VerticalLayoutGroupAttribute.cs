using System;
using System.Diagnostics;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    [Conditional("UNITY_EDITOR")]
    public class VerticalLayoutGroupAttribute : GroupBaseAttribute
    {
        public VerticalLayoutGroupAttribute(string path) : base(path) { }
    }
}