using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class Slips : MonoBehaviour
{
    public GameEvent onSubtitle;
    public GameEvent onPlayerState;
    bool playerInBound;
    bool inFocus;
    public float scaleFactor;
    public GameObject Canvas;
    private Transform orignalTransform;
    Transform Player;

    private void Start()
    {
        orignalTransform = transform;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    public void Update()
    {
        if (inFocus)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Escp");
                transform.parent = null;
                
                transform.localScale /= scaleFactor;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                inFocus = false;
                onPlayerState.Raise(this, true);


            }
        }
        if (playerInBound)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.parent = Canvas.transform;
                transform.position = Canvas.transform.position + new Vector3(0,0,-1f);
                transform.localScale *= scaleFactor/5;
                transform.rotation = Quaternion.Euler(90, 180, 0);
                onPlayerState.Raise(this, false);
                inFocus = true;
            }
        }

        
    }





    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            onSubtitle.Raise(this, "[E] to look at paper");
            playerInBound = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onSubtitle.Raise(this, "");
            playerInBound = false;
        }
    }
}
