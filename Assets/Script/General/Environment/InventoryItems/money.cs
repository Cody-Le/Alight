using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{

    public GameObject bottle;
    private Transform Player = null;
    // Start is called before the first frame update
    public void BuyBottle()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        if(Player == null) { return; }
        if(bottle == null) { return; }
        Debug.LogError("Bought Bottle");
        Instantiate(bottle);
    }
}
