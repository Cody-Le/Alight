using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseCursorState : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    
}
