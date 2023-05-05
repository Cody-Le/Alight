using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_passive : MonoBehaviour
{


    public int sceneIndex;
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
            SceneManager.LoadScene(sceneIndex);
            
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
