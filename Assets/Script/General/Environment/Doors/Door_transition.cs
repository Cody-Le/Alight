using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_transition : MonoBehaviour
{


    
    public string sceneName;
    public bool savePlayer = false;
    bool playerInCollider = false;
    GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (playerInCollider)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                if (savePlayer)
                {
                    saveSystem.SavePlayer(Player, SceneManager.GetActiveScene().buildIndex);
                }

                if(sceneName == "") { return; }

                SceneManager.LoadScene(sceneName);

                if (SceneManager.GetSceneByName(sceneName).IsValid())
                {
                    SceneManager.LoadScene(sceneName);
                }
                else
                {
                    Debug.LogError("Scene " + sceneName + " is not a valid scene, therefore is not loaded");
                }
                
            }
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
