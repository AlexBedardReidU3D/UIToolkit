namespace Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field)]  
    public class CustomLabel : System.Attribute  
    {  
        private readonly string m_Label;  
    
        public CustomLabel(string label)  
        {  
            m_Label = label;  
        }

        public string GetText() => m_Label;
    } 
}