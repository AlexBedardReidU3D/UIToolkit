//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by UXML Generator
//     version 0.0.1
//     from ScriptGenerator
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(MyClass))]
public class @MyClassCustomInspector : UnityEditor.Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        var MyClassInstance= (MyClass)target;

        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();
        myInspector.Add(new Label("This is a custom inspector"));
        // Load and clone a visual tree from UXML
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Custom Inspectors/MyClass/MyClassUXML.uxml");
        visualTree.CloneTree(myInspector);

        //Button Attribute Calls
        //----------------------------------------------------------//

        var classType = MyClassInstance.GetType();

        //TestButton2 Action Callback
        var TestButton2Method = classType.GetMethod("TestButton2", BindingFlags.NonPublic | BindingFlags.Instance);
        myInspector.Q<UnityEngine.UIElements.Button>("TestButton2").clickable.clicked += () =>
        {
            TestButton2Method.Invoke(MyClassInstance, default);
        };

        //TestButton Action Callback
        var TestButtonMethod = classType.GetMethod("TestButton", BindingFlags.NonPublic | BindingFlags.Instance);
        myInspector.Q<UnityEngine.UIElements.Button>("TestButton").clickable.clicked += () =>
        {
            TestButtonMethod.Invoke(MyClassInstance, default);
        };

        //----------------------------------------------------------//

        //Custom Label Bindings
        //----------------------------------------------------------//

        //Element [Dynamic Group] (GroupBox) Binding to -> myDynamicLabel

        myInspector.Q<GroupBox>("Dynamic Group")
        	.Q<Label>(null, GroupBox.labelUssClassName).bindingPath = "myDynamicLabel";

        //Element [FoldoutGroup] (Foldout) Binding to -> myDynamicLabel

        myInspector.Q<Foldout>("FoldoutGroup")
        	.Q<Label>(null, Foldout.textUssClassName).bindingPath = "myDynamicLabel";

        //Element [m_MyFloat] (FloatField) Binding to -> myDynamicLabel

        myInspector.Q<FloatField>("m_MyFloat")
        	.Q<Label>(null, FloatField.labelUssClassName).bindingPath = "myDynamicLabel";

        //----------------------------------------------------------//

        // Return the finished inspector UI
        return myInspector;
    }
}
