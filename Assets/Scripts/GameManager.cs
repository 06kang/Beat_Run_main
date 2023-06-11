using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool pause, isPlay,isMove;

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
        if (Input.anyKeyDown)
        {
            firstFade.enabled = true;
            isPlay = true;
            isMove = true;
        }
    }
}
