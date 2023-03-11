using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitle : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;


    private void setSubtitle(string newText)
    {
        subtitleText.text = newText;
    }
    public void UpdateText(Component sender, object data)
    {
        if (data is string)
        {
            string text = (string)data;
            setSubtitle(text);

        }
    }
}
