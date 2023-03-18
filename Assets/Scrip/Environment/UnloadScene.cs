using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadScene : MonoBehaviour
{
    public string sceneName;
    private void OnEnable()
    {
        SceneManager.UnloadScene(sceneName);
    }
}
