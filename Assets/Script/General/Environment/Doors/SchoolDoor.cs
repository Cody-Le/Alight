using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SchoolDoor : MonoBehaviour
{
    public GameEvent onSubtitle;
    public string SceneName;
    public string getBagString;
    bool playerInBound;


    private void Start()
    {
        playerInBound = false;
    }


    private void Update()
    {
        if (playerInBound)
        {

            if (!saveSystem.CheckBagState())
            {
                onSubtitle.Raise(this, getBagString);
                return;
            }



            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!SceneManager.GetSceneByName(SceneName).IsValid())
                {
                    Debug.LogError("Scene Name of " + SceneName + " does not exist");
                }
                SceneManager.LoadScene(SceneName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            playerInBound = true;
            onSubtitle.Raise(this, "[E] to get out");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInBound = false;
            onSubtitle.Raise(this, "");
        }
    }
}
