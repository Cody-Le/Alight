using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class clicked : MonoBehaviour
{
    public UnityEvent useItem;
    public GameEvent inventoryEvent;
    private float timeFromFirstClick = 0f;
    private bool isCounting = false;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timeFromFirstClick == 0f)
            {
                isCounting = true;
            }
            else
            {
                if(timeFromFirstClick < 1f)
                {
                    Debug.Log("DoubleClicked");
                    useItem.Invoke();
                    if(inventoryEvent != null) { inventoryEvent.Raise(this, false); }
                    
                }
            }
        }

        if (isCounting)
        {
            timeFromFirstClick += Time.deltaTime;
        }

        if(timeFromFirstClick > 1f)
        {
            isCounting = false;
            timeFromFirstClick = 0f;
        }
    }
}
