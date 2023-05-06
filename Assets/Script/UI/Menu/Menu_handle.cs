using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_handle : MonoBehaviour
{
    public void NewGame()
    {
        saveSystem.SaveGameState(1);
        SceneManager.LoadScene("Classroom");
    }

    public void ContinueGame()
    {
        if (!saveSystem.CheckGameState()) { return; }
        gameState level = saveSystem.LoadGameState();
        SceneManager.LoadScene(level.level);
    }

    public void Settngs()
    {

    }
}
