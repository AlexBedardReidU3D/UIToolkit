﻿using System;
using System.Diagnostics;

namespace Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Struct)]  
    [Conditional("UNITY_EDITOR")]
    public class GenerateUXMLAttribute : System.Attribute  
    {  
        public GenerateUXMLAttribute() { }
    } 
}