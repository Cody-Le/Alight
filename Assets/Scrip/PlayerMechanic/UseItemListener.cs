using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseItemListener : MonoBehaviour
{
    public UnityEvent response;
    public void UseItem()
    {
        if(response == null) { return; }
        response.Invoke();
    }
}
