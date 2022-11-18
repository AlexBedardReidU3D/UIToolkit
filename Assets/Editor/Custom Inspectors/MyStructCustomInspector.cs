using UnityEditor;
using UnityEngine.UIElements;

namespace Editor.Custom_Inspectors
{
    [CustomPropertyDrawer(typeof(MyStruct))]
    public class MyStructCustomInspector : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Create a new VisualElement to be the root of our inspector UI
            VisualElement myInspector = new VisualElement();
            myInspector.Add(new Label("This is a custom inspector"));
            // Load and clone a visual tree from UXML
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Custom Inspectors/MyStructUXML.uxml");
            visualTree.CloneTree(myInspector);

            // Return the finished inspector UI
            return myInspector;
        }
    }
}