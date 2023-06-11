using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public Vector2 target;
    public float smoothTime = 10f;
    public float xVelocity = 2f;
    public float yVelocity = 2f;


    // Start is called before the first frame update
    void Start()
    {
    }
    
    public void MoveOB()
    {
        float newPositionX = Mathf.SmoothDamp(transform.position.x, target.x ,ref xVelocity ,smoothTime);
        float newPositionY = Mathf.SmoothDamp(transform.position.y, target.y, ref yVelocity, smoothTime);
        transform.position = new Vector2(newPositionX,newPositionY);
    }
}
