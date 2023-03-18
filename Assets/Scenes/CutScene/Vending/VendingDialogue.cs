using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingDialogue : MonoBehaviour
{
    public GameEvent setSubtitle;
    public void setText(string text)
    {
        setSubtitle.Raise(this, text);
    }
}
