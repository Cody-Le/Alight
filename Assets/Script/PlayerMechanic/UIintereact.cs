using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class UIintereact : MonoBehaviour
{

    [InspectorName("GameEvents")]
    public GameEvent OnInventoryEvent;
    public GameEvent OnEscScreen;

    [InspectorName("Toggle Feature")]
    public bool Inventory_on;
    public bool EscScreen_on;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if ((OnInventoryEvent != null) && Inventory_on)
            {
                OnInventoryEvent.Raise(this, 0);
            }
            
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if ((OnEscScreen != null) && EscScreen_on)
            {
                OnEscScreen.Raise(this, 0);
            }

        }
    }



}
