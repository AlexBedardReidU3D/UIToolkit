namespace Attributes
{
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
}