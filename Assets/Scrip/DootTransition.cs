using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionalTransition : MonoBehaviour
{

    public int SceneIndex;
    public Animator ani_controller;
    bool isOpen = false;
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.E)){
                if (isOpen)
                {
                    ani_controller.SetTrigger("DoorClose");
                    isOpen = false;
                }
                else
                {
                    ani_controller.SetTrigger("DoorOpen");
                    isOpen = true;
                }
                if(SceneIndex != -1)
                {
                    SceneManager.LoadScene(SceneIndex);
                    
                }
            }
        }
    }
}
