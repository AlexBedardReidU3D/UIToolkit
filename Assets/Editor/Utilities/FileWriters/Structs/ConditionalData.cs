using System;
using Attributes;

namespace Editor.Utilities.FileWriters
{
    public struct ConditionalData
    {
        public Type ParentType;
        public string ParentName;

        public ConditionalBaseAttribute conditionalAttribute;
    }
}