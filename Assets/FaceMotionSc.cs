using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMotionSc : MonoBehaviour
{
    Animator faceAnim;
    public static FaceMotionSc instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null)
        instance = this;
    }
    void Start()
    {
        faceAnim = GameObject.FindGameObjectWithTag("face").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
