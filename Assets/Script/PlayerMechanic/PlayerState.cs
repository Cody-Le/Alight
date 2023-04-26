using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    Movement script_playerMovement;
    Pickup script_pickup;
    private void Start()
    {
        script_pickup = GetComponent<Pickup>();
        script_playerMovement = GetComponent<Movement>();
    }

    public void DisablePlayer()
    {
        script_playerMovement.enabled = false;
        script_pickup.enabled = false;
    }

    public void EnablePlayer()
    {
        script_playerMovement.enabled = true;
        script_pickup.enabled = true;
    }
}
