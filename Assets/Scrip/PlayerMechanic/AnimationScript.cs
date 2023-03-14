using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationScript : MonoBehaviour
{
    public Animator animController;
    public void SetAnimationEvent(Component send, object data)
    {
        if (data is string)
        {
            string trigger = (string)data;
            animController.SetTrigger(trigger);
        }
    }
}