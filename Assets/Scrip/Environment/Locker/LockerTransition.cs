using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockerTransition : MonoBehaviour
{

    public Animator ani_controller;
    bool isOpen = false;

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
                if (isOpen)
                {
                    ani_controller.SetTrigger("close");
                    isOpen = false;
                }
                else
                {
                    ani_controller.SetTrigger("open");
                    isOpen = true;
                }
           
            }
        }
    }
}
