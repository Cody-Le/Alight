using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    CharacterController controller;
    public float movementSpeed = 1f;
    public float runningFactor = 1.2f;
    public float positionClamp = 32f;
    public float rotationSpeed = 0.5f;

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




    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
  
    }

    // Update is called once per frame
    void Update()
    {

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
                if (isRunning)
                {
                    animator.SetTrigger("Running");
                }
                else
                {
                    animator.SetTrigger("Walking");
                }

                
               
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

            isRunning = true;

        }else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }



        if (positionClamp != 0f)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -positionClamp, positionClamp), transform.position.y, Mathf.Clamp(transform.position.z, -positionClamp, positionClamp));
        }







    }
}
