using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public GameEvent onAnimation;
    public GameEvent onPlayerState;
    public string animationTrigger = "fall";


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            bool state = saveSystem.CheckWaterState();
           
            if (!saveSystem.CheckWaterState())
            {
                onAnimation.Raise(this, animationTrigger);
                onPlayerState.Raise(this, false);
            }
        }
    }
}
