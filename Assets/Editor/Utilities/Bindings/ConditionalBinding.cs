using System.Reflection;
using UnityEngine.UIElements;

namespace Editor.Utilities
{
    public class ConditionalBinding : SimpleBinding
    {
        public readonly bool ExpectedResult;
        public object TargetValue;

        public ConditionalBinding(in VisualElement savedElement,
            in MemberInfo memberInfo,
            in object targetValue,
            in bool expectedResult) : base(savedElement, memberInfo)
        {
            ExpectedResult = expectedResult;
            TargetValue = targetValue;
        }
        
        public ConditionalBinding(in VisualElement savedElement,
            in MemberInfo memberInfo,
            in bool expectedResult) : base(savedElement, memberInfo)
        {
            ExpectedResult = expectedResult;
            TargetValue = true;
        }

    }
}