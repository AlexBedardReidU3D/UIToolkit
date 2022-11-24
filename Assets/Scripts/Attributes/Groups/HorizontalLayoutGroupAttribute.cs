using System;
using System.Diagnostics;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    [Conditional("UNITY_EDITOR")]
    public class HorizontalLayoutGroupAttribute : GroupBaseAttribute
    {
        public HorizontalLayoutGroupAttribute(string path) : base(path) { }
    }
}