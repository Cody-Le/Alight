using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public float spaceBetweenItem = 10f;
    public float scrollSpeed = 100f;
    public Transform startingPosition;

    public GameObject ItemUseMenu;
    private float scrollValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ItemUseMenu.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        scrollValue += Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed;
    
        int i = 0;
        foreach (Transform child in transform)
        {
            child.position = startingPosition.position + new Vector3(i * spaceBetweenItem + scrollValue, 0);
            i++;
        }
    }

    public void ShowItemUse(GameObject obj)
    {
        if (ItemUseMenu.active)
        {
            ItemUseMenu.SetActive(false);
        }
        else
        {
         
            ItemUseMenu.SetActive(true);
            ItemUseMenu.transform.position = Input.mousePosition;
        }
       
    }





}
