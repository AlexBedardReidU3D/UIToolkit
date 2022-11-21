using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[GenerateUXML]
public class MyClass : MonoBehaviour
{
    [CustomLabel("Label 1"), ReadOnly]
    public int myInt;
    [CustomLabel("My Number"), DisplayAsString]
    public int myInt2;
    [SerializeField, CustomLabel("Label 2")]
    private float m_MyFloat;
    /*private float m_MyFloatPrivate;
    
    public long myLong;
    public Vector2 myV2;
    public Vector3 myV3;
    public Vector4 myV4;
    public Rect myRect;
    public Bounds myBounds;
    public Vector2Int myV2Int;
    public Vector3Int myV3Int;
    public Texture2D myTexture;*/

    public int[] intArray;
    public List<int> intList;

    public List<MyStruct> myStructList;
    public List<MyPropertyTest> myPropertyTestList;

    [ReadOnly]
    public GameObject myGameObject;

    public MyStruct myStruct;
    
    public MyPropertyTest myPropertyTest;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Button]
    private void TestButton()
    {
        Debug.Log("TestButton");
    }
    
    [Button("My Custom Button")]
    private void TestButton2()
    {
        Debug.Log("TestButton2");
    }
    
    public long myLong;
    public Vector2 myV2;
    public Vector3 myV3;
    public Vector4 myV4;
}
