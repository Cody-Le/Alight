using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intereaction : MonoBehaviour
{
    // Start is called before the first frame update

    public string text;
    public GameEvent onChangeText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            onChangeText.Raise(this, text);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            onChangeText.Raise(this, "");
        }
    }
}
