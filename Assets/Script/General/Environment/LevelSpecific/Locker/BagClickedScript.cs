using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BagClickedScript : MonoBehaviour
{
    public GameObject bagObject;

    private void Awake()
    {
        if (saveSystem.CheckBagState()) //deactivating the bag if the bag is already been obtained. 
        {
            bagObject.active = false;
        }
    }

    public void onClicked()
    {
        saveSystem.SaveBag(true);

       
        SceneManager.LoadScene("Classroom");
    }
}
