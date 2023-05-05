using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vending : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvent onChangeText;
    private bool playerInZone = false;

    private void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                onChangeText.Raise(this, "At the time, I only had five dollars, just enough for a water.");

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
       {
            playerInZone = true;
            onChangeText.Raise(this, "[TAB] to look at inventory");
       }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
          
            onChangeText.Raise(this, "");

            SceneManager.LoadScene("Vending_cutscene");

        }
    }

 
}
