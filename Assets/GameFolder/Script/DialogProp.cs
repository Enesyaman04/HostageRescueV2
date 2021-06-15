using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Template")]
public class DialogProp : ScriptableObject
{
    public string otherGuySentence;
    public DialogProp[] dialogProp;
    public string[] animCallWord;
    public float[] motionDegree;
    public string[] ourSentece;
}
