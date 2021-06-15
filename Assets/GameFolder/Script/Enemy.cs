using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Observer.OnFinishEvent.AddListener(YouCanDoIt);
    }

    private void OnDisable()
    {
        Observer.OnFinishEvent.RemoveListener(YouCanDoIt);
    }

    void YouCanDoIt(string str)
    {
        if (str == "Win")
        {

        }
        else
        {

        }
    }
}
