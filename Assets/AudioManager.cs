using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Talk;
    public AudioClip[] Talk2;
    public AudioSource Voice;
    public AudioSource Voice2;
    public int count;
    public int count2;
    public bool isEnable;
    public bool isEnable2;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnable)
        {
            if (!Voice.isPlaying)
            {
                Voice.clip = Talk[count];
                Voice.Play();
                count++;
            }
        }
        if (isEnable2)
        {
            if (!Voice2.isPlaying)
            {
                Voice2.clip = Talk2[count2];
                Voice2.Play();
                count2++;
            }
        }
    }

    public void TalkCh()
    {
       
    }
}
