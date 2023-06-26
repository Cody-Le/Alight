using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] allCameras;
    public Camera childCamera;
    AudioSource source;

    void Start()
    {
        allCameras = GameObject.FindGameObjectsWithTag("MainCamera");
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        allCameras = GameObject.FindGameObjectsWithTag("MainCamera");
        if (other.transform.tag == "Player")
        {
            if(allCameras.Length > 0)
            {
                source.Play();
                foreach(GameObject cam in allCameras)
                {
                    cam.GetComponent<AudioListener>().enabled = false;  
                    cam.SetActive(false);
                }
            }
            childCamera.gameObject.SetActive(true);
            childCamera.gameObject.GetComponent<AudioListener>().enabled = true;    
            
        }
    }
}
