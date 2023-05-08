using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UIHandle : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject EscScreen;

    private bool esc_state;
    private bool inventory_state;

    public void Start()
    {
        esc_state = false;
        inventory_state = false;
        Inventory.SetActive(inventory_state);
        EscScreen.SetActive(esc_state);
    }

    public void toggleInventory(Component sender, object data)
    {
        inventory_state = !inventory_state;
        Inventory.SetActive(inventory_state);
    }

    public void toggleEscScreen(Component sender, object data)
    {
        esc_state = !esc_state;
        EscScreen.SetActive(esc_state);
    }

}
