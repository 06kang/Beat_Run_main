using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector2 target = new Vector2(7.76f, -8.365f);
    public void MoveOB()
    {
        Vector2 velo = Vector2.zero;
        transform.position = Vector2.SmoothDamp(transform.position, target, ref velo, 0.1f);
    }
}
