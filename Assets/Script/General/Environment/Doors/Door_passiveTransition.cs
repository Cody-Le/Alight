using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_passiveTransition : MonoBehaviour
{


    public string sceneName;
    public bool savePlayer = false;
    bool playerInCollider = false;
    GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInCollider)
        {
            if (savePlayer)
            {
                saveSystem.SavePlayer(Player, SceneManager.GetActiveScene().buildIndex);
            }
            if (sceneName == "") { return; }
            SceneManager.LoadScene(sceneName);

        }




    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInCollider = true;
            Player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInCollider = false;
            Player = null;
        }
    }
}
