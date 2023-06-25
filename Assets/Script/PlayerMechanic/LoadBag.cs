using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBag : MonoBehaviour
{
    public GameObject Bag;

    
    private void Start()
    {
        
        bool state = saveSystem.CheckBagState();
    
        Bag.SetActive(state);
    }
}
