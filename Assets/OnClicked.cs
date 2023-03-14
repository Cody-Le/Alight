using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClicked : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("MOUSE IS CLICKED");
        }
    }
}
