using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[GenerateUXML]
public class MyClass : MonoBehaviour
{
    [CustomLabel("Label 1")]
    public int myInt;
    [SerializeField, CustomLabel("Label 2")]
    private float m_MyFloat;
    private float m_MyFloatPrivate;
    
    public long myLong;
    public Vector2 myV2;
    public Vector3 myV3;
    public Vector4 myV4;
    public Rect myRect;
    public Bounds myBounds;
    public Vector2Int myV2Int;
    public Vector3Int myV3Int;
    public Texture2D myTexture;
    public GameObject myGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
