using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscScreen : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public void gotoHomeScreen()
    {
        saveSystem.SavePlayer(Player, SceneManager.GetActiveScene().buildIndex);
        saveSystem.SaveGameState(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        saveSystem.SavePlayer(Player, SceneManager.GetActiveScene().buildIndex);
        saveSystem.SaveGameState(SceneManager.GetActiveScene().name);
        Application.Quit();
    }


    public void Settings()
    {

    }
}
