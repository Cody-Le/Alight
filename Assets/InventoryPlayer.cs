using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryPlayer : MonoBehaviour
{
    public UnityEvent InventoryOn;
    public UnityEvent InventoryOff;
    bool InventoryState = false;
    public GameObject Inventory;


    private void Start()
    {
        if (InventoryOn == null)
            InventoryOn = new UnityEvent();

        InventoryOn.AddListener(TurnOnInventory);

        if (InventoryOff == null)
            InventoryOff = new UnityEvent();

        InventoryOff.AddListener(TurnOffInventory);

    }



    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryState)
            {
                //Close Inventory
                if(InventoryOn == null)
                {
                    return;
                }
                InventoryOff.Invoke();
                InventoryState = false;
            }
            else
            {
                //Open Inventory
                if (InventoryOn == null)
                {
                    return;
                }
                InventoryOn.Invoke();
                InventoryState = true;
            }
        }
    }

    void TurnOnInventory()
    {
        if (Inventory != null)
        {
            Inventory.SetActive(true);
        }

        

    }

    void TurnOffInventory()
    {
        if (Inventory != null)
        {
            Inventory.SetActive(false);
        }
        
    }
}



