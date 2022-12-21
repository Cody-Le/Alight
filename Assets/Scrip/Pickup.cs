using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;

public class Pickup : MonoBehaviour
{

    public Vector3 pickableHalfExtent;
    public GameObject holdingObject;
    public LayerMask pickableLayer;
    public Vector3 holdingOffSet;
    GameObject pickingObject;

    public GameObject FindClosestPickup()
    {
        GameObject[] pickableDetected;
        pickableDetected = GameObject.FindGameObjectsWithTag("pickable");
        GameObject pickingUp = null;
        float distance = pickableHalfExtent.magnitude;
        Vector3 position = transform.position;
        foreach(GameObject pickable in pickableDetected)
        {
            Vector3 r = pickable.transform.position - position;
            if (r.magnitude < distance)
            {
                pickingUp = pickable;
                distance = r.magnitude;
            }
        }

        return pickingUp;
    }


    void Update()
    {
       if (Input.GetMouseButtonDown(0)){

            if (pickingObject == null) {
                pickingObject = FindClosestPickup();
                if(pickingObject != null)
                {
                    pickingObject.transform.parent = holdingObject.transform;
                    pickingObject.transform.localPosition = holdingOffSet;
                    pickingObject.GetComponent<Rigidbody>().useGravity = false;
                    pickingObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    pickingObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    pickingObject.GetComponent<BoxCollider>().isTrigger = true;
                    pickingObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                
                }
            }
            else
            {
                pickingObject.GetComponent<Rigidbody>().useGravity = true;
                pickingObject.GetComponent<BoxCollider>().isTrigger = false;
                pickingObject.transform.parent = null;
                pickingObject = null;



            }
       }


       
    }
}
