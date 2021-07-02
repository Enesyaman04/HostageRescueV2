using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SliderControl : MonoBehaviour
{
    public static SliderControl instance;
    [SerializeField] Image ımage;
    [SerializeField] RawImage ımage2;
    [SerializeField] Image ımage3;
    [SerializeField] float offset;

    public float fillAmount;

    [SerializeField] float timeFrequency;
    float time;

    Color imageColor;
    Color İmage2Color;
    Color İmage3Color;

    bool isActive = true;

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

    private void Start()
    {
        fillAmount = ımage.fillAmount;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            //float value = Random.Range(ımage.fillAmount - (offset / 1000), ımage.fillAmount + (offset / 1000));
            //ımage.fillAmount = value;

           // time += Time.deltaTime;
            //if (time > timeFrequency)
            //{
            //    ımage.fillAmount = fillAmount;
            //    time = 0;
            //}
        }

        if (fillAmount >= 0.95 && isActive == true)
        {
            isActive = false;
            Observer.OnFinishEvent?.Invoke("Fail");
            GameManager.instance.LevelFail();
            FaceMotionSc.instance.TurnoffCamNon();
        }
        else if (fillAmount <= 0.05 && isActive == true)
        {
            isActive = false;
            Observer.OnFinishEvent?.Invoke("Win");
            FaceMotionSc.instance.TurnoffCamNon();
           GameManager.instance.LevelComplete();
            GameManager.instance.longobj.SetActive(false);
        }
    }
    public void FillAmuntPlus(float motionDegree2)
    {
        print("------         " + motionDegree2);
        ımage.fillAmount = ımage.fillAmount + motionDegree2;
        fillAmount = ımage.fillAmount;
        imageColor = new Color(ımage.fillAmount,1-ımage.fillAmount, 0, 1);
        ımage.color = imageColor;
        ımage2.color = imageColor;
        ımage3.color = imageColor;
    }
}
