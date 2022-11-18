using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(MyClass))]
public class MyClassCustomInspector : UnityEditor.Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();
        myInspector.Add(new Label("This is a custom inspector"));
        // Load and clone a visual tree from UXML
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Custom Inspectors/MyClassUXML.uxml");
        visualTree.CloneTree(myInspector);

        // Return the finished inspector UI
        return myInspector;
    }
}