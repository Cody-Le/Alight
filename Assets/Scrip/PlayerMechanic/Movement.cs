using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    CharacterController controller;
    public float movementSpeed = 1f;
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


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        DontDestroyOnLoad(gameObject);
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

        Vector3 move = transform.forward * zMovement;
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
        


        if (positionClamp != 0f)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -positionClamp, positionClamp), transform.position.y, Mathf.Clamp(transform.position.z, -positionClamp, positionClamp));
        }







    }
}
