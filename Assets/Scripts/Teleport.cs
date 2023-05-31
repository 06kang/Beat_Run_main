using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport tp;
    public Transform teleportPoint;

    public bool isTrigger;


    public void teleport(Transform player)
    {
        player.position = teleportPoint.position;
        //isTrigger = true;
    }

}
