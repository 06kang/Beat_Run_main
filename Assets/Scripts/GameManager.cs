using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool pause, isPlay, SoundPlay;

    public FadeOutAnim firstFade;

    public AudioT audioT;

    public ObjectMove obMove;

    void Awake()
    {
        instance = this;
        pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !isPlay)
        {
            firstFade.ActiveFade();
            isPlay = true;
            SoundPlay = true;
        }
        if(SoundPlay && !firstFade.isFade)
        {
            pause = false;
            audioT.Play();
            SoundPlay = false;
        }
 
    }
}
