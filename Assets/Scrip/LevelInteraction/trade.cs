using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trade : MonoBehaviour
{

    public GameObject[] tradeObject;
    public GameObject[] wallDisappear;
    public Transform instantiatePosition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        tradeQualities quality = collision.gameObject.GetComponent<tradeQualities>();
        if (quality != null)
        {
            GameObject key = Instantiate(tradeObject[quality.tradeValue]);
            key.transform.position = instantiatePosition.position;
            if(wallDisappear.Length > 0)
            {
                wallDisappear[quality.tradeValue].active = false;
            }
            Destroy(collision.gameObject);
            

        }
    }
}
