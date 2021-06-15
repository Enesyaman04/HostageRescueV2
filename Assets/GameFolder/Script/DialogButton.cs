using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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


    public void LogParameters(string animTriggerWord_, float action_, string ourSentence_, DialogProp dialog)
    {
        Visulasion();
        animTriggerWord = animTriggerWord_;
        ourSentence = ourSentence_;
        motionDegree = action_;
        dialogProp = dialog;
        sentenceText.text = ourSentence;
    }

    public void CallDialogManager()
    {
        Debug.Log(motionDegree);
        SliderControl.instance.fillAmount += motionDegree / 100;
        Debug.Log(SliderControl.instance.fillAmount);
        dialogManager.LogButtonParameters(dialogProp);
    }


    void Visulasion()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(Vector3.zero, GameManager.instance.buttonDuration));
        sequence.Append(transform.DOScale(Vector3.one, GameManager.instance.buttonDuration));
        sequence.Append(transform.DOScale(Vector3.one * 0.8f, GameManager.instance.buttonDuration));
        sequence.Append(transform.DOScale(Vector3.one, GameManager.instance.buttonDuration));
    }
}
