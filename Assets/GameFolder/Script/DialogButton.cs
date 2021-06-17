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

    ColorBlock currentcolor;
    Button thebutton;
    public void LogParameters(string animTriggerWord_, float action_, string ourSentence_, DialogProp dialog)
    {
        Visulasion();
        animTriggerWord = animTriggerWord_;
        ourSentence = ourSentence_;
        motionDegree = action_;
        dialogProp = dialog;
        sentenceText.text = ourSentence;
        thebutton = GetComponent<Button>();
        currentcolor = thebutton.colors;
        print(motionDegree);
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
    }

    public void CallDialogManager()
    {

        Debug.Log(motionDegree);
        titresim.instance.med();
        StartCoroutine(CallDialogManagerWait());
    }

     IEnumerator CallDialogManagerWait()
    {
        yield return new WaitForSeconds(1f);
        SliderControl.instance.FillAmuntPlus(motionDegree/100);
        Debug.Log(SliderControl.instance.fillAmount);
        dialogManager.LogButtonParameters(dialogProp);
    }

    void Visulasion()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(Vector3.zero, GameManager.instance.buttonDuration));
       // sequence.Append(transform.DOScale(Vector3.one, GameManager.instance.buttonDuration));
        sequence.Append(transform.DOScale(Vector3.one * 1f, GameManager.instance.buttonDuration));
        //sequence.Append(transform.DOScale(Vector3.one, GameManager.instance.buttonDuration));
    }
}
