using System.Collections;
using System.Collections.Generic;
using Tabtale.TTPlugins;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float buttonDuration;
    public GameObject longobj;

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
        TTPCore.Setup();
    }
    private void Start()
    {
        LevelStart();
    }

    public void LevelComplete()
    {
        TTPGameProgression.FirebaseEvents.MissionComplete(null);
    }
    public void LevelFail()
    {
        TTPGameProgression.FirebaseEvents.MissionFailed(null);
    }
    public void LevelStart()
    {
        TTPGameProgression.FirebaseEvents.MissionStarted(1,
            null);
    }

    public void LevelRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
