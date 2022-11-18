using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Add Horizontal Layout Groups
//TODO Add Vertical Layout Groups
//TODO Add TitleGroup
//TODO Add Foldout Group
//TODO Add HideInInspector
//TODO Add EnableIf/DisableIf
//TODO Add EnableInEditor/DisableInEditor
//TODO Add EnableInPlayMode/DisableInPlaymode

[System.AttributeUsage(System.AttributeTargets.Field)]  
public class CustomLabel : System.Attribute  
{  
    private readonly string m_Text;  
    
    public CustomLabel(string text)  
    {  
        m_Text = text;  
    }

    public string GetText() => m_Text;
}  

[System.AttributeUsage(System.AttributeTargets.Field)]  
public class ReadOnly : System.Attribute  
{  
    public ReadOnly()  
    {  
    }
} 
[System.AttributeUsage(System.AttributeTargets.Field)]  
public class DisplayAsString : System.Attribute  
{  
    public DisplayAsString()  
    {  
    }
} 

[System.AttributeUsage(System.AttributeTargets.Method)]  
public class Button : System.Attribute  
{  
    private readonly string m_Text;  
    
    public Button(string text)  
    {  
        m_Text = text;  
    }
    
    public Button()  
    {  
    }

    public string GetText() => m_Text;
} 

[System.AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Struct)]  
public class GenerateUXML : System.Attribute  
{  
    public GenerateUXML() { }
}  
