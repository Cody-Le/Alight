using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NMDoorTransition : MonoBehaviour
{


    public int sceneIndex;
    // Start is called before the first frame update
    bool playerInCollider = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInCollider)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }




    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInCollider = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInCollider = false;
        }
    }
}
