using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class lookAt : MonoBehaviour
{

    public float mouseSensitivity = 1f;
    public Transform playerBody;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float XInput = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float YInput = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= YInput;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0,0);
        
        playerBody.Rotate(Vector3.up * XInput);
    }
}
