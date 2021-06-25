using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Template")]
public class DialogProp : ScriptableObject
{
    public string otherGuySentence;
    public DialogProp[] dialogProp;
    public string[] animCallWord;
    public float[] motionDegree;
    public string[] ourSentece;
    public string[] LongDialog;
    public Sprite Hosimage;
    public Sprite[] Buttonimage;
}
