using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public FadeOutAnim fadeInImg;
    bool isActive;
    public void Change()
    {
        fadeInImg.ActiveFade();
        isActive = true;
    }

    private void Update()
    {
        if (!fadeInImg.isFade && isActive)
        {
            SceneManager.LoadScene("InGame");
            isActive = false;
        }
    }
}
