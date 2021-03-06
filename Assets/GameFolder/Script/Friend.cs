using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Friend : MonoBehaviour
{
    Animator animator;
   
    public GameObject Police;
    public GameObject CanvasObj;
    public GameObject WinObj;
    public GameObject FailObj;
    public GameObject muzzlep;
    public float faceblend;
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
            animator.SetBool("Win", true);
           
            Camera.main.transform.DOMove(new Vector3(-1.24f,3.35f,4.97f),2f);
            Camera.main.transform.DORotate(new Vector3(15f,11.36f,0),2f);
            CanvasObj.SetActive(false);
            WinObj.SetActive(true);
            StartCoroutine(winpolice());
            AudioManager.instance.isEnable = false;
            AudioManager.instance.isEnable2 = false;

            //titresim.instance.med();
        }
        else
        {
            Camera.main.transform.DOMove(new Vector3(-1.24f, 3.35f, 4.97f), 2f);
            Camera.main.transform.DORotate(new Vector3(15f, 11.36f, 0), 2f);
            animator.SetBool("Fail", true);
            CanvasObj.SetActive(false);
            muzzlep.SetActive(true);
            StartCoroutine(muzz());
            FailObj.SetActive(true);
            AudioManager.instance.isEnable = false;
            AudioManager.instance.isEnable2 = false;
            //titresim.instance.med();
        }
    }
    IEnumerator winpolice()
    {
        yield return new WaitForSeconds(1f);
        Police.SetActive(true);
    }
    IEnumerator muzz()
    {
        yield return new WaitForSeconds(.5f);
      
    }

}
