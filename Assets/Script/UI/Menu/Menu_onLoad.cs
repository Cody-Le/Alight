using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_onLoad : MonoBehaviour
{
    GameObject menu;

    [InspectorLabel("Menu Objects")]
    public Button Btn_continue;
    public Button Btn_newGame;
    public Button Btn_setting;



    private void Awake()
    {
        menu = this.gameObject;
        if (!saveSystem.CheckGameState())
        {
            Btn_continue.interactable = false;
           
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
