using System;
using System.Collections;
using System.Collections.Generic;
using Attributes;
using UnityEngine;

[GenerateUXML]
public class MyClass : MonoBehaviour
{
    [SerializeField, TitleGroup("Dynamic Group", "$myDynamicLabel")]
    private string myDynamicLabel;
    
    [SerializeField, CustomLabel("$myDynamicLabel")]
    private float m_MyFloat;
    [CustomLabel("My Number"), DisplayAsString, FoldoutGroup("FoldoutGroup", "$myDynamicLabel")]
    public int myInt2;

    public bool thisIsAToggle;

    [InfoBox("Here is some information about this field"), BoxGroup("MyStructBox")]
    public MyStruct myStruct;
    
    [InfoBox("Here is some information about this field")]
    public MyStruct myStruct2;
    
    public MyPropertyTest myPropertyTest;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    [Button, FoldoutGroup("FoldoutGroup"), DisableInEditorMode]
    private void DisableInEditorButton()
    {
        Debug.Log("TestButton");
    }
    
    [Button("My Custom Button"), VerticalLayoutGroup("Row1")]
    private void TestButton2()
    {
        Debug.Log("TestButton2");
    }
    
    [DisableInEditorMode]
    public long myLong;
    [DisableInPlayMode]
    public Vector2 myV2;
    [DisableInPlayMode]
    public Vector3 myV3;
    public Vector4 myV4;
}
