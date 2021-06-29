using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DialogButton : MonoBehaviour
{
    [SerializeField] TMP_Text sentenceText;
    [SerializeField] DialogManager dialogManager;
    [SerializeField] DialogProp dialogProp;

    public string animTriggerWord;
    public float motionDegree;
    public string ourSentence;
    public int callDialogIndex;
    public string longdialog;
    public GameObject longtextobj;
    public Image Buttim;
    public float _timeWait;

    ColorBlock currentcolor;
    Button thebutton;
    public void LogParameters(string animTriggerWord_, float action_, string ourSentence_, DialogProp dialog,Sprite sp,Sprite btnsprt,string longdialog_)
    {
        Visulasion();
        animTriggerWord = animTriggerWord_;
        ourSentence = ourSentence_;
        motionDegree = action_;
        dialogProp = dialog;
        longdialog = longdialog_;
        sentenceText.text = ourSentence;
        thebutton = GetComponent<Button>();
        Buttim.GetComponent<Image>().sprite = btnsprt;
        currentcolor = thebutton.colors;
        if (motionDegree < 0)
        {
            currentcolor.pressedColor = Color.green;
            thebutton.colors = currentcolor;
        }
        else
        {
            currentcolor.pressedColor = Color.red;
            thebutton.colors = currentcolor;
        }
        currentcolor.selectedColor = Color.white;
        thebutton.colors = currentcolor;
    }

    public void CallDialogManager()
    {
        Debug.Log(motionDegree);
        dialogManager.longText.text = longdialog;
        if (motionDegree < 0)
        {
            currentcolor.selectedColor = Color.green;
            thebutton.colors = currentcolor;
        }
        else
        {
            currentcolor.selectedColor = Color.red;
            thebutton.colors = currentcolor;
        }
        SliderControl.instance.FillAmuntPlus(motionDegree / 100);
        StartCoroutine(closeLong());
        StartCoroutine(CallDialogManagerWait());
    }

     IEnumerator CallDialogManagerWait()
    {
        yield return new WaitForSeconds(1f);
        longtextobj.SetActive(true);
        AudioManager.instance.isEnable = true;
        dialogManager.LogButtonParameters(dialogProp);
        dialogManager.otherGuyContain.transform.DOMoveZ(15000f, 0.1f);
        dialogManager.otherGuyContain.transform.DOMoveZ(15, 0.1f).SetDelay(3f).OnComplete(()=> {
            dialogManager.cleartxt();
        });
        FaceMotionSc.instance.ReactionFace();
    }
    IEnumerator closeLong()
    {
        yield return new WaitForSeconds(3.5f);
        AudioManager.instance.isEnable = false;
        AudioManager.instance.count = 0;
        StartCoroutine(opensound());
        StartCoroutine(closesound());
        longtextobj.SetActive(false);
    }
    IEnumerator opensound()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.isEnable2 = true;
    }
    IEnumerator closesound()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.instance.isEnable2 = false;
        AudioManager.instance.count2 = 0;
    }
    void Visulasion()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.zero, GameManager.instance.buttonDuration));
       
        sequence.Append(transform.DOScale(Vector3.one * 1f, GameManager.instance.buttonDuration).SetDelay(5f));
    }
}
