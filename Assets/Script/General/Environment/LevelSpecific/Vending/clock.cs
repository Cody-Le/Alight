using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class clock : MonoBehaviour
{
    public GameEvent animTrigger;
    public GameEvent setPlayerState;
    public GameEvent setSubtitleText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animTrigger.Raise(this, "LookClock");
            StartCoroutine(playerStandStill());
            StartCoroutine(dialog());
        }
    }

    private IEnumerator playerStandStill()
    {
        Debug.Log("ASHAHAHSHHAHSHHA");
        setPlayerState.Raise(this, false);
        yield return new WaitForSeconds(3f);
        setPlayerState.Raise(this, true);
        Debug.Log("BLUEUEUEUUEUEUEUEU");
    }

    private IEnumerator dialog()
    {
        setSubtitleText.Raise(this, "8:30, I still have time");
        yield return new WaitForSeconds(2.5f);
        setSubtitleText.Raise(this, "I can still use the bus");
        yield return new WaitForSeconds(2.5f);
        setSubtitleText.Raise(this, "");
    }
}
