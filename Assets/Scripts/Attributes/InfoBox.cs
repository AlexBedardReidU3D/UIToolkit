using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class InfoBox : Attribute
    {
        public readonly string InfoText;
        
        public InfoBox(string infoText)
        {
            InfoText = infoText;
        }
    }
}