using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FaceMotionSc : MonoBehaviour
{
    Animator faceAnim;
    GameObject faceCam;
    public static FaceMotionSc instance;
    float facevalue;
    float currentvalue;
    public float lerptime;
    bool Reactionbool;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        faceAnim = GetComponent<Animator>();
        faceCam = GameObject.FindGameObjectWithTag("face");
        //faceCam.SetActive(false);
    }
    public void ReactionFace()
    {
        faceCam.SetActive(true);
        if(SliderControl.instance.fillAmount <=0.25)
        {
          
            currentvalue = -1;
            Reactionbool = true;
            DOTween.To(() => facevalue, x => facevalue = x, currentvalue, lerptime).OnComplete(() => {
                Reactionbool = false;
                facevalue = currentvalue;
               // StartCoroutine(TurnoffCam());
            });
        }else if(SliderControl.instance.fillAmount >0.25 && SliderControl.instance.fillAmount <= 0.40)
        {
            currentvalue = -0.5f;
            Reactionbool = true;
            DOTween.To(() => facevalue, x => facevalue = x, currentvalue, lerptime).OnComplete(() => {
                Reactionbool = false;
                facevalue = currentvalue;
              //  StartCoroutine(TurnoffCam());
            });
        }
        else if (SliderControl.instance.fillAmount > 0.40 && SliderControl.instance.fillAmount <= 0.60)
        {
            currentvalue = 0f;
            Reactionbool = true;
            DOTween.To(() => facevalue, x => facevalue = x, currentvalue, lerptime).OnComplete(() => {
                Reactionbool = false;
                facevalue = currentvalue;
               // StartCoroutine(TurnoffCam());
            });
        }
        else if (SliderControl.instance.fillAmount > 0.60 && SliderControl.instance.fillAmount <= 0.80)
        {
            currentvalue = 0.5f;
            Reactionbool = true;
            DOTween.To(() => facevalue, x => facevalue = x, currentvalue, lerptime).OnComplete(() => {
                Reactionbool = false;
                facevalue = currentvalue;
                //StartCoroutine(TurnoffCam());
            });
          
        }
        else if (SliderControl.instance.fillAmount > 0.80 && SliderControl.instance.fillAmount <= 1)
        {
            currentvalue = 1f;
            Reactionbool = true;
            DOTween.To(() => facevalue, x => facevalue = x, currentvalue, lerptime).OnComplete(()=> {
                Reactionbool = false;
                facevalue = currentvalue;
                //StartCoroutine(TurnoffCam());
            });
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Reactionbool == true)
        {
            faceAnim.SetFloat("faceblend", facevalue);
        }
    }
    IEnumerator TurnoffCam()
    {
        yield return new WaitForSeconds(2f);
        //faceCam.SetActive(false);
    }
    public void TurnoffCamNon()
    {
        faceCam.SetActive(false);
    }
}
