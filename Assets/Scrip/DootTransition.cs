using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DootTransition : MonoBehaviour
{

    public int SceneIndex;
    public Animator ani_controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.E)){
                ani_controller.SetTrigger("DoorOpen");
                if(SceneIndex != -1)
                {
                    SceneManager.LoadScene(SceneIndex);
                }
            }
        }
    }
}
