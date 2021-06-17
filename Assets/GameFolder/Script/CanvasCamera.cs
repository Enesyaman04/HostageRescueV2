using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCamera : MonoBehaviour
{
    Canvas _canvas;
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;
    }

}
