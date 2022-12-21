using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicked : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Item has been clicked");
        }
    }
}
