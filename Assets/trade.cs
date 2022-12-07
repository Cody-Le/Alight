using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trade : MonoBehaviour
{

    public GameObject[] tradeObject;





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
            Instantiate(tradeObject[quality.tradeValue]);
            Destroy(collision.gameObject);

        }
    }
}
