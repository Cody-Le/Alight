using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChaseExit: MonoBehaviour
{
    public PlayableDirector busAnimation;
    public GameObject Enemy;

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            busAnimation.Play();
            Enemy.active = false;
        }
    }
}
