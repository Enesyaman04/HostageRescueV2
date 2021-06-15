using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public DialogProp dialogProp;

    [SerializeField] TMP_Text otherGuyText;
    [SerializeField] GameObject[] buttons;

    void Start()
    {
        LogButtonParameters(dialogProp);
    }

    public void LogButtonParameters(DialogProp dialogProp)
    {
        otherGuyText.text = dialogProp.otherGuySentence;

        for (int i = 0; i < buttons.Length; i++)
        {
            DialogButton dialogButton = buttons[i].GetComponent<DialogButton>();
            dialogButton.LogParameters(dialogProp.animCallWord[i], dialogProp.motionDegree[i], dialogProp.ourSentece[i], dialogProp.dialogProp[i]);
        }
    }
}
