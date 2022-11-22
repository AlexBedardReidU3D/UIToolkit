namespace Attributes
{
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
}