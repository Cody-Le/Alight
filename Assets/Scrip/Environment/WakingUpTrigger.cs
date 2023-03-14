using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakingUpTrigger : MonoBehaviour
{
    public GameEvent OnWakeUp;

    private void Start()
    {
        OnWakeUp.Raise(this, "WakeUp");
    }
}
