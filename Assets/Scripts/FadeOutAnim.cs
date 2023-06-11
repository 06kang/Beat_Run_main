using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FadeOutAnim : MonoBehaviour
{

    public float fadeSpeed = 1.5f;
    public bool fadeInOnStart = false;
    public bool fadeOutOnExit = false;

    private CanvasGroup canvasGroup;


    void Update()
    {
        
        
        
    }
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
        StartCoroutine(FadeOut());

    }

    IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        GameManager.instance.pause = false;
        if (GameManager.instance.isPlay) GameManager.instance.audioT.Play();
        if (GameManager.instance.isMove) GameManager.instance.obMove.MoveOB();
    }


}
