using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour
{
    bool over = false;
    public string Messages;
    public GameEvent gameEvent;



    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        if (!over)
        {
            over = true;
            gameEvent.Raise(this, Messages);

        }
    }

    private void OnMouseExit()
    {
        over = false;
    }
}
