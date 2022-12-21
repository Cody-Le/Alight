using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_InRange : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject outLine;
    public Vector3 DetectSize;
    public LayerMask DetectionMask;
    public Vector3 toLocation;
    public bool teleportOnOpen;
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
            if(outLine != null)
            {
                Debug.Log(CheckPlayer);
                if (CheckPlayer)
                {
                    if (teleportOnOpen)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            GameObject player = GameObject.FindGameObjectWithTag("Player");
                            player.GetComponent<CharacterController>().enabled = false;
                            player.transform.position = toLocation + new Vector3(0, player.transform.position.y, 0);
                            player.GetComponent<CharacterController>().enabled = true;
                        }
                    }
                    outLine.SetActive(true);
                }
                else
                {
                    outLine.SetActive(false);
                }
            }
        }
    }
}
