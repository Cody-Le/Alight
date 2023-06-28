using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightPath : MonoBehaviour
{
    public GameObject afternoonLight;
    public GameObject infiniteHallway;

    public void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (!saveSystem.CheckStoryState(index))
        {
            Debug.LogError("No Game State for " + index.ToString());
            afternoonLight.SetActive(false);
            infiniteHallway.SetActive(true);
        
        }else
        {
            afternoonLight.SetActive(true);
            infiniteHallway.SetActive(false);
        }

        

        
    }
}
