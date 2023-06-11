using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Transform player;
    public enum Direction {Left, right, up, down };
    public Direction dir;

    bool isActive;
    public void OnDash()
    {
        isActive = true;
        
        StartCoroutine(move());
    }
    public void OffDash()
    {
        isActive = false;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator move()
    {
        while (isActive)
        {
            yield return new WaitForFixedUpdate();
            Vector2 vec = Vector2.zero;
            if(dir == Direction.Left)
            {
                vec = Vector2.left;
            }
            else if(dir == Direction.right)
            {
                vec = Vector2.right;
            }
            else if (dir == Direction.up)
            {
                vec = Vector2.up;
            }
            else
            {
                vec = Vector2.down;
            }
            player.Translate(vec * 7 * Time.deltaTime);
        }
    }
}
