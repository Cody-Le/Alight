using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_anim : MonoBehaviour
{

    public int SceneIndex;
    public Animator ani_controller;
    bool isOpen = false;
    public bool savePlayer = false;
    public GameObject Player;

    // Start is called before the first frame update

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
                    
                    if (savePlayer)
                    {
                        Player = GameObject.FindGameObjectWithTag("Player");
                        saveSystem.SavePlayer(Player, SceneManager.GetActiveScene().buildIndex);
                    }
                    SceneManager.LoadScene(SceneIndex);
                }
            }
        }
    }
}
