using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioT : MonoBehaviour
{
    public float bgmtime;
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        bgm.time = bgmtime;
        bgm.Play();
    }
}
