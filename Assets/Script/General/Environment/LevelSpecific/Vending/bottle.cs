using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bottle : MonoBehaviour
{
    public GameEvent onTextEvent;
    private bool playerInRange = false;
    GameObject Player;

    private void Update()
    {
        if (!playerInRange){return;}
        if (Input.GetKeyDown(KeyCode.E))
        {
            saveSystem.SaveStoryState(2, SceneManager.GetActiveScene().buildIndex);
            onTextEvent.Raise(this, "drinking water");
            StartCoroutine(afterDrink(2f));
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") { return; }


        onTextEvent.Raise(this, "[E] to drink water");
        Player = other.gameObject;
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") { return; }
        onTextEvent.Raise(this, "");
        playerInRange = false;
        Player = null;
    }


    IEnumerator afterDrink(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        saveSystem.SavePlayer(Player.gameObject, SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Vending_cutscene");
        
    }



}
