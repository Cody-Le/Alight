using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mother : MonoBehaviour
{
    public GameEvent onSubtitle;
    public string NextScene;
    public string text;
    bool playerInBound;
    public GameObject playerSave;

    private void Update()
    {
        
        if (playerInBound)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            saveSystem.SavePlayer(playerSave, index);
            Debug.LogWarning(index);
            saveSystem.SaveStoryState(30, index);
            SceneManager.LoadScene(NextScene);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            onSubtitle.Raise(this, text);
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
