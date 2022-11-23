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
    
    [CustomLabel("Label 1"), ReadOnly, VerticalLayoutGroup("Row1")]
    public int myInt;
    [CustomLabel("My Number"), DisplayAsString, FoldoutGroup("titleGroup", "This is my Group")]
    public int myInt2;
    [SerializeField, CustomLabel("Label 2")]
    private float m_MyFloat;

    public int[] intArray;
    public List<int> intList;

    public List<MyStruct> myStructList;
    public List<MyPropertyTest> myPropertyTestList;

    [ReadOnly, VerticalLayoutGroup("Row1")]
    public GameObject myGameObject;

    [InfoBox("Here is some information about this field")]
    public MyStruct myStruct;
    
    public MyPropertyTest myPropertyTest;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    [Button, FoldoutGroup("titleGroup", "This is my Group")]
    private void TestButton()
    {
        Debug.Log("TestButton");
    }
    
    [Button("My Custom Button"), VerticalLayoutGroup("Row1")]
    private void TestButton2()
    {
        Debug.Log("TestButton2");
    }
    
    public long myLong;
    public Vector2 myV2;
    public Vector3 myV3;
    public Vector4 myV4;
}
