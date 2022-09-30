using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 4f;
    public float walkSpeed = 4f;
    public float sprintSpeed = 8f;
    public float gravity = 109.8f;
    public float jumpHeight = 0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (Input.GetKey(KeyCode.LeftShift))
            
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
    //recieve the inputs for our Inputmanager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y <0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        // Debug.Log(playerVelocity.y);
    }
    public void Jump()
    {
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -1.0f * gravity);
    }
}