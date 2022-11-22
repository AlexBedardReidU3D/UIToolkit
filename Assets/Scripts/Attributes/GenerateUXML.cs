using System;

namespace Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Struct)]  
    public class GenerateUXML : System.Attribute  
    {  
        public GenerateUXML() { }
    } 
}