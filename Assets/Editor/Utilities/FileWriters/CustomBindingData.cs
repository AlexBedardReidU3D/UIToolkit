using System.Reflection;
using UnityEngine.UIElements;

namespace Editor.Utilities
{
    public class CustomBindingData
    {
        public readonly VisualElement SavedElement;
        public readonly MemberInfo MemberInfo;
        public object CurrentValue;

        public CustomBindingData(in VisualElement savedElement, in MemberInfo memberInfo, in object currentValue)
        {
            SavedElement = savedElement;
            MemberInfo = memberInfo;
            CurrentValue = currentValue;
        }

        public bool RequiresUpdate(in object newValue)
        {
            if (CurrentValue == null)
                return true;
            
            return CurrentValue.Equals(newValue) == false;
        }
    }
}