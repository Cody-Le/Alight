using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [Header("Moving Parameters")]
    CharacterController controller;
    public float movementSpeed = 1f;
    public float runningFactor = 1.2f;
    public float rotationSpeed = 0.5f;

    [Header("Jumping Parameters")]
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    


    public float jumpHeight = 2f;
    [Header("Animation Parameter")]
    public Animator animator;
    bool isGrounded = false;
    [HideInInspector] public bool isWalking = false;
    bool isBacking = false;
    [HideInInspector]public bool isRunning = false;
    bool isActive = true;
    bool canStopRunning = true;
    public float timeBeforeStopRunning = 0.2f;


    // Start is called before the first frame update
    void Start()
    { 
        controller = GetComponent<CharacterController>();
        //UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isActive) { 
            
                
            return; 
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        } 


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2);
        }


        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        

        if (!isBacking && zMovement < 0)
        {
            Vector3 scale = transform.localScale;
            isBacking = true;
            transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z * -1);

        }
        else if (zMovement >= 0 && isBacking)
        {
            Vector3 scale = transform.localScale;
            isBacking = false;
            transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z * -1);
            transform.Rotate(new Vector3(0f, 180f, 0f));
        }


        Vector3 move = transform.forward * zMovement;
        if (isRunning)
        {
            move *= runningFactor;
        }
        controller.Move(move * movementSpeed * Time.deltaTime);

        float rotate = xMovement * rotationSpeed;
        transform.Rotate(Vector3.up * rotate * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }

        if (((Mathf.Abs(move.magnitude) + Mathf.Abs(rotate)) > 0) && !isWalking)
        {
           
            isWalking = true;
            animator.SetTrigger("Walking");

        }else if(((Mathf.Abs(move.magnitude) + Mathf.Abs(rotate)) == 0) && isWalking)
        {
            StartCoroutine(doubleClickBugStop());
            if (canStopRunning)
            {
               
                isWalking = false;

                animator.SetTrigger("Idling");
            }
        }

        



      
    }

   public void setPlayerState(Component sender, object data)
    {
        if(data is bool)
        {
            isActive = (bool)data;
        }
    }
   

    IEnumerator doubleClickBugStop()
    {
        canStopRunning = false;
        yield return new WaitForSeconds(timeBeforeStopRunning);
        canStopRunning = true;
    }
}
