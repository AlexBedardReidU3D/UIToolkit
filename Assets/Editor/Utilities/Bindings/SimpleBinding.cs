using System.Reflection;
using UnityEngine.UIElements;

namespace Editor.Utilities
{
    public class SimpleBinding
    {
            public readonly VisualElement SavedElement;
            public readonly MemberInfo MemberInfo;
        
            public object CurrentValue;

            public SimpleBinding(
                in VisualElement savedElement,
                in MemberInfo memberInfo)
            {
                SavedElement = savedElement;
                MemberInfo = memberInfo;

                CurrentValue = default;
            }

            public bool RequiresUpdate(in object newValue)
            {
                if (CurrentValue == null)
                    return true;
            
                return CurrentValue.Equals(newValue) == false;
            }
    }
}