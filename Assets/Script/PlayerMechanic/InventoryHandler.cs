using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public GameObject Inventory;
    public void inventoryController(Component sender, object data)
    {
        if (data is bool)
        {
            bool state = (bool)data;
            Inventory.SetActive(state);
        }
        
    }
}
