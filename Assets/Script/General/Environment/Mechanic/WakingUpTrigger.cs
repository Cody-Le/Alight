using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WakingUpTrigger : MonoBehaviour
{
    public GameEvent OnWakeUp;
    public GameEvent SetPlayerState;
    private void Start()
    {
        
        if (!saveSystem.CheckStoryState(SceneManager.GetActiveScene().buildIndex))
        {
            OnWakeUp.Raise(this, "WakeUp");
            StartCoroutine(controlFreeze());
            saveSystem.SaveStoryState(1, SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            OnWakeUp.Raise(this, "Idling");
        }
        
    }

    IEnumerator controlFreeze()
    {
        Debug.Log("SETTING THE PLAYER TO FALSE");
        SetPlayerState.Raise(this, false);
        yield return new WaitForSeconds(4f);
        SetPlayerState.Raise(this, true);
    }
}
