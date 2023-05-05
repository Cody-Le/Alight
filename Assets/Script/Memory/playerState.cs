using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class playerState
{
    public bool isBagged;
    public float[] position;
   


    public playerState(GameObject player)
    {

        if(player.tag != "Player")
        {
            Debug.LogError(player.name + " is not a player tagged object");
            return;
        }
        isBagged = false;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        Debug.Log(position);

    }
}
