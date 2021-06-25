using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public DialogProp dialogProp;
    public TMP_Text longText;
    public Text Bpm;
    float Bpmvalue;
    [SerializeField] TMP_Text otherGuyText;
    public GameObject otherGuyContain;
    [SerializeField] GameObject[] buttons;
    float time;
    public float timeFrequency;
    public Image hosimage;
    public string[] arrayTemp;
    public float timetext;
    bool first;
    public static DialogManager instance;
    void Start()
    {
        LogButtonParameters(dialogProp);
    }
    private void Awake()
    {
        instance = this;
    }
    public void LogButtonParameters(DialogProp dialogProp)
    {
        otherGuyText.text = " ";
        arrayTemp = dialogProp.otherGuySentence.Split(' ');
        if (!first)
        {
            cleartxt();
            first = true;
        }
        hosimage.GetComponent<Image>().sprite = dialogProp.Hosimage;

        for (int i = 0; i < buttons.Length; i++)
        {
            DialogButton dialogButton = buttons[i].GetComponent<DialogButton>();
            dialogButton.LogParameters(dialogProp.animCallWord[i], dialogProp.motionDegree[i], dialogProp.ourSentece[i], dialogProp.dialogProp[i], dialogProp.Hosimage, dialogProp.Buttonimage[i], dialogProp.LongDialog[i]);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeFrequency)
        {
            if (SliderControl.instance.fillAmount <= 0.25)
            {
                Bpmvalue = Random.Range(70, 80);
            }
            else if (SliderControl.instance.fillAmount > 0.25 && SliderControl.instance.fillAmount <= 0.40)
            {
                Bpmvalue = Random.Range(81, 90);
            }
            else if (SliderControl.instance.fillAmount > 0.40 && SliderControl.instance.fillAmount <= 0.60)
            {
                Bpmvalue = Random.Range(110, 120);
            }
            else if (SliderControl.instance.fillAmount > 0.60 && SliderControl.instance.fillAmount <= 0.80)
            {
                Bpmvalue = Random.Range(120, 140);
            }
            else if (SliderControl.instance.fillAmount > 0.80 && SliderControl.instance.fillAmount <= 1)
            {
                Bpmvalue = Random.Range(141, 170);
            }
            Bpm.text = Bpmvalue.ToString();
            time = 0;
        }
    }
    int count;
    int count1;
    public char[] Harfler;
    public IEnumerator showtxt()
    {
        yield return new WaitForSeconds(timetext);
        if (count1 < Harfler.Length)
        {
            otherGuyText.text = otherGuyText.text + Harfler[count1];
            count1++;
            StartCoroutine(showtxt());
        }
        else
        {
            count1 = 0;
            StartCoroutine(showtxt1());
        }
    }
    public IEnumerator showtxt1()
    {
        yield return new WaitForSeconds(timetext);
        if (count < arrayTemp.Length)
        {
            otherGuyText.text = otherGuyText.text + " ";
            Harfler = arrayTemp[count].ToCharArray();
            count++;
            StartCoroutine(showtxt());
        }
        else
            count = 0;
    }
    public void cleartxt()
    {
        print("dd");
        count = 0;
        otherGuyText.text = " ";
        StartCoroutine(showtxt1());
    }
}
