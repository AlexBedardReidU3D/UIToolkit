using System;

namespace Attributes
{
    //TODO Add Horizontal Layout Groups
    //TODO Add Vertical Layout Groups
    
    //TODO Add TitleGroup
    //TODO Add Foldout Group
    
    //TODO Add HideInInspector
    //TODO Add EnableIf/DisableIf
    //TODO Add EnableInEditor/DisableInEditor
    //TODO Add EnableInPlayMode/DisableInPlaymode

    public abstract class GroupsBase : Attribute
    {
        //private readonly string m_Label;  
        private readonly string m_Path;
        private readonly string m_Name;
        
        public GroupsBase(/*string label, */string path)
        {
            //m_Label = label;
            m_Path = path;

            var pathSplit = m_Path.Split('/');
            m_Name = pathSplit[pathSplit.Length - 1];
        }
        
        //public string GetLabel() => m_Label;
        public string GetPath() => m_Path;
        public string GetName() => m_Name;
    }
    
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class VerticalLayoutGroup : GroupsBase
    {
        public VerticalLayoutGroup(string path) : base(path) { }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class HorizontalLayoutGroup : GroupsBase
    {
        public HorizontalLayoutGroup(string path) : base(path) { }
    }
    
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class TitleGroup : GroupsBase
    {
        private readonly string m_Label;  
        
        public readonly bool noUnderline;  
        
        public TitleGroup(string path, string label = "", bool dontUnderline = false) : base(path)
        {
            m_Label = label;
            
            noUnderline = dontUnderline;
        }

        public string GetLabel() => string.IsNullOrWhiteSpace(m_Label) ? GetName() : m_Label;
    }
    
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class FoldoutGroup : GroupsBase
    {
        private readonly string m_Label;  
        
        public FoldoutGroup(string path, string label = "") : base(path)
        {
            m_Label = label;
        }

        public string GetLabel() => string.IsNullOrWhiteSpace(m_Label) ? GetName() : m_Label;
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class BoxGroup : GroupsBase
    {
        private readonly string m_Label;  
        
        public BoxGroup(string path, string label = "") : base(path)
        {
            m_Label = label;
        }

        public string GetLabel() => string.IsNullOrWhiteSpace(m_Label) ? GetName() : m_Label;
    }
}