using System.Diagnostics;

namespace Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field)]  
    [Conditional("UNITY_EDITOR")]
    public class DisplayAsStringAttribute : System.Attribute  
    {  
        public DisplayAsStringAttribute()  
        {  
        }
    } 
}