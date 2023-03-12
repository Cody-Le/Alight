using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vending : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvent onChangeText;
    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
       {
     
            onChangeText.Raise(this, "[TAB] to look at inventory");
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
