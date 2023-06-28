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
            afternoonLight.SetActive(false);
            infiniteHallway.SetActive(true);
            return;
        }

        if(saveSystem.LoadStoryState(index).state != 0)
        {
            afternoonLight.SetActive(true);
            infiniteHallway.SetActive(false);
        }
        else
        {
            afternoonLight.SetActive(false);
            infiniteHallway.SetActive(true);
        }

        
    }
}
