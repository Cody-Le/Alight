using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakingUpTrigger : MonoBehaviour
{
    public GameEvent OnWakeUp;
    public GameEvent SetPlayerState;
    private void Start()
    {
        OnWakeUp.Raise(this, "WakeUp");
        StartCoroutine(controlFreeze());
    }

    IEnumerator controlFreeze()
    {
        Debug.Log("SETTING THE PLAYER TO FALSE");
        SetPlayerState.Raise(this, false);
        yield return new WaitForSeconds(4f);
        SetPlayerState.Raise(this, true);
    }
}
