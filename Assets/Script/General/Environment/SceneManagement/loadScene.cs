using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public string sceneName;
    public void loadSaidScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
