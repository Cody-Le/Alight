using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Display Items")]
    public float spaceBetweenItem = 10f;
    public float scrollSpeed = 100f;
    public Transform startingPosition;
    private float scrollValue = 0f;

 
    
    
    // Start is called before the first frame update
    void Start()
    {
      
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

 




}
