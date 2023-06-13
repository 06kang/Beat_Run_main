using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float lerpTime = 0.5f;
    public float currentTime = 0;
    public float delayTime;
    bool pause, first;
    public bool positionFix; 
    // Start is called before the first frame update
    void Start()
    {
        if(positionFix)  startPos = this.transform.position;
        pause = true;
    }
    
    public void Update()
    {
        if (GameManager.instance.pause) return;
        else if(!first)
        {
            first = true;
            Invoke("Off_Pause", delayTime);
        }

        if (!pause)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= lerpTime)
            {
                currentTime = lerpTime;
            }
            float t = currentTime / lerpTime;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);
            this.transform.position = Vector3.Lerp(startPos, endPos, t);
            if(Vector3.Distance(transform.position, endPos) < 0.1f)
            {
                transform.position = endPos;
                pause = true;
            }
        }
        

    }

    void Off_Pause()
    {
        pause = false;
    }
}
