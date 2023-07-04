using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTextTrigger : MonoBehaviour
{
    public string text;
    public GameEvent onSubtitle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onSubtitle.Raise(this, text);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            onSubtitle.Raise(this, "");
        }
    }
}
