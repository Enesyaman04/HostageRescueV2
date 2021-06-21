using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class test2 : MonoBehaviour
{
    public RawImage images;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(speed,0);
        images.material.mainTextureOffset = pos;
    }
}
