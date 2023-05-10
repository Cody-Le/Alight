using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class busInteraction : MonoBehaviour
{
    public GameEvent onSubtitle;
    public PlayableDirector playerBus;
    public GameObject Stranger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onSubtitle.Raise(this, "[E] to get on bus");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onSubtitle.Raise(this, "");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerBus.Play();
                Stranger.active = false;

            }
        }
    }
}
