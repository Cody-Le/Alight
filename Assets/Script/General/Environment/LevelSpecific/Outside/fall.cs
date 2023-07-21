using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fall : MonoBehaviour
{
    public GameEvent onAnimation;
    public GameEvent onPlayerState;
    public string animationTrigger = "fall";
    public string CutSceneName = "";


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            bool state = saveSystem.CheckWaterState();
           
            if (!saveSystem.CheckWaterState())
            {
                onAnimation.Raise(this, animationTrigger);
                onPlayerState.Raise(this, false);
                StartCoroutine(openCutscene());
            }
        }
    }



    IEnumerator openCutscene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(CutSceneName);
    }
}
