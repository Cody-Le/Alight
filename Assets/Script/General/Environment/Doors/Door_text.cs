using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_text : MonoBehaviour
{
    public GameEvent onSubtitle;
    public string text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") { return; }
        onSubtitle.Raise(this, text);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag != "Player") { return; }
        onSubtitle.Raise(this, "");
    }
}
