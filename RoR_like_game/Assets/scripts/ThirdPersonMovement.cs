using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 6f;
    public float jump = 3f;
    public float gravity = -12f;
    public float turnSmoothTime = 0.1f;
    public float groundDistance = 0.2f;

    public float sprintSpeed = 13f;
    [SerializeField] public float health = 100f;


    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded;
    
    //Locks cursor to middle of screen
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is in contanct with the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        //varibles for charcter movement
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
       
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        if (direction.magnitude > 0){

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f).normalized * Vector3.forward.normalized;
            controller.Move(moveDir.normalized * speed * Time.deltaTime); 

            //code for sprinting
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                speed = sprintSpeed;
            }

            if(Input.GetKeyUp(KeyCode.LeftShift)){
                speed = 6f;
            }
        }
        //code for jumping
        if(Input.GetButtonDown("Jump") && isGrounded){

            velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
        }
        //code to caculate fall speed after jump
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void DamagePlayer(float enemyDamage){
        health -= enemyDamage;
    }
}
