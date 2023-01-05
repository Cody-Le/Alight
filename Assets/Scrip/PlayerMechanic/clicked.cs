using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clicked : MonoBehaviour
{
    public GameObject inventory;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (inventory == null)
            {
                return;
            }

            inventory.GetComponent<Inventory>().ShowItemUse(this.gameObject);

        }
    }
}
