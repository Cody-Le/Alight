using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UIHandle : MonoBehaviour
{
    public GameObject ScreenObject;

   
    private bool inventory_state;

    public void Start()
    {
       
        inventory_state = false;
        ScreenObject.SetActive(inventory_state);
        
    }

    public void toggleScreenObject(Component sender, object data)
    {
        inventory_state = !inventory_state;
        ScreenObject.SetActive(inventory_state);
    }

}
