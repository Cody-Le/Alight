using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] allCameras;
    public Camera childCamera;

    void Start()
    {
        allCameras = GameObject.FindGameObjectsWithTag("MainCamera");
 
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        allCameras = GameObject.FindGameObjectsWithTag("MainCamera");
        if (other.transform.tag == "Player")
        {
            if(allCameras.Length > 0)
            {
                foreach(GameObject cam in allCameras)
                {
                    cam.SetActive(false);
                }
            }
            childCamera.gameObject.SetActive(true);
            
        }
    }
}
