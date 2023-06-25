using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_handle : MonoBehaviour
{
    public void NewGame()
    {
        saveSystem.ResetAllPlayerState();
        saveSystem.ResetAllStoryState();
        saveSystem.SaveGameState("Classroom");
        saveSystem.ResetBagState();
        SceneManager.LoadScene("Classroom");
    }

    public void ContinueGame()
    {
        if (!saveSystem.CheckGameState()) {Debug.LogWarning("No Game State have been save"); return; }
        gameState level = saveSystem.LoadGameState();
        SceneManager.LoadScene(level.levelName);
    }

    public void Settngs()
    {

    }
}
