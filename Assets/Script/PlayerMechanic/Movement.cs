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
    public float positionClamp = 32f;
    public float rotationSpeed = 0.5f;

    [Header("Jumping Parameters")]
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    public Animator animator;


    public float jumpHeight = 2f;

    bool isGrounded = false;
    bool isWalking = false;
    bool isBacking = false;
    bool isRunning = false;
    bool isActive = true;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
  
    }

    // Update is called once per frame
    void Update()
    {

        if (!isActive) { return; }

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

        if((Mathf.Abs(move.magnitude) + Mathf.Abs(rotate)) > 0)
        {
            if(isWalking == false)
            {
                isWalking = true;
                animator.SetTrigger("Walking");
             
            }
        }
        else
        {
            if (isWalking == true)
            {
                isWalking = false;
                animator.SetTrigger("Idling");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
            Debug.Log(animator.GetBool("isRunning"));
            isRunning = true;

        }else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", false);
            isRunning = false;
        }
        if (positionClamp != 0f)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -positionClamp, positionClamp), transform.position.y, Mathf.Clamp(transform.position.z, -positionClamp, positionClamp));
        }
    }

   public void setPlayerState(Component sender, object data)
    {
        if(data is bool)
        {
            isActive = (bool)data;
        }
    }
    
}
