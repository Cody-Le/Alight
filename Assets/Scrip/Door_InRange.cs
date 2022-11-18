using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_InRange : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject outLine;
    public Vector3 DetectSize;
    public LayerMask DetectionMask;
    public bool ActiveFeature;
    void Start()
    {
        outLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool CheckPlayer = Physics.CheckBox(transform.position, DetectSize, transform.rotation, DetectionMask);
        if (ActiveFeature)
        {
            if (CheckPlayer)
            {
                outLine.SetActive(true);
            }
            else
            {
                outLine.SetActive(false);
            }
        }
    }
}
