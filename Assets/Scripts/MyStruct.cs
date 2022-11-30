using System;
using UIToolkit.Attributes;
using UnityEngine;

[Serializable, GenerateUXML]
public struct MyStruct
{
    public int test;

    [Button]
    private void TestButton()
    {
        Debug.Log(nameof(MyStruct.TestButton));
    }
}
[Serializable]
public class MyPropertyTest
{
    public int test;
    
    [Button]
    private void TestButton()
    {
        Debug.Log(nameof(MyPropertyTest.TestButton));
    }
}