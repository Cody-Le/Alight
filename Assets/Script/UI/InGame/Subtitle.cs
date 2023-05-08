using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Subtitle : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
   
    private bool enable = false;

    

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
            if (text == "")
            {
                this.GetComponent<Image>().enabled = false;
            }
            else
            {
                this.GetComponent<Image>().enabled = true;
            }

        }
    }
}
