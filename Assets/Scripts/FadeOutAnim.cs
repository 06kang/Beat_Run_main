using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FadeOutAnim : MonoBehaviour
{

    public float fadeSpeed = 1.5f;
    public bool fadeInOnStart = false;
    public bool fadeOutOnExit = false;
    public bool isFade;
    private CanvasGroup canvasGroup;
    public enum FadeKind { FadeIn, FadeOut};
    public FadeKind fade;

    void Update()
    {
        
        
        
    }
    private void Start()
    {
        
    }

    IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        isFade = false;
        gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        
        isFade = false;
        gameObject.SetActive(false);
    }


    public void ActiveFade()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (fade == FadeKind.FadeIn)
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 0f;
            StartCoroutine(FadeIn());
            
        }
        else
        {
            enabled = true;
            canvasGroup.alpha = 1f;
            StartCoroutine(FadeOut());
            
        }
        isFade = true;
    }

}
