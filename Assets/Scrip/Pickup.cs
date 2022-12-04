using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;

public class Pickup : MonoBehaviour
{

    public Vector3 pickableHalfExtent;
    public Vector3 pickupOffset;
    public LayerMask pickableLayer;
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
       if (Input.GetKeyDown(KeyCode.E)){

            if (pickingObject == null) {
                bool pickableInRange = Physics.CheckBox(transform.position, pickableHalfExtent, Quaternion.identity, pickableLayer);

                if (pickableInRange)
                {
                    pickingObject = FindClosestPickup();
                    pickingObject.transform.parent = transform;
                    pickingObject.GetComponent<Rigidbody>().useGravity = false;
                    pickingObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    pickingObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    pickingObject.GetComponent<SphereCollider>().isTrigger = true;
                    pickingObject.transform.position = Vector3.zero;
                    pickingObject.transform.localPosition = pickupOffset;

                }
            }
            else
            {
                pickingObject.GetComponent<Rigidbody>().useGravity = true;
                pickingObject.GetComponent<SphereCollider>().isTrigger = false;
                pickingObject.transform.parent = null;
                pickingObject = null;



            }
       }


       
    }
}
