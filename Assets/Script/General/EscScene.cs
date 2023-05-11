using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscScene : MonoBehaviour
{
    public string sceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(sceneName == "") { return; }
            SceneManager.LoadScene(sceneName);
        }
    }
}
