using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Input Actions References
    InputAction moveAction;
    InputAction jumpAction;

    int jumpBuffer;
    int jumpForce;

    [SerializeField]
    private int speed = 5;

    // Character Controller
    CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpBuffer = 0;
        jumpForce = 0;
        controller = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0,-5,0);
        Vector2 moveValue = moveAction.ReadValue<Vector2>() * speed;
        movement.x = moveValue.x;
        movement.z = moveValue.y;
        if (controller.isGrounded && jumpAction.IsPressed())
        {
            jumpBuffer = 30;
        }
        if(jumpBuffer != 0)
        {
            if(jumpBuffer > 15)
            {
                jumpForce += 3;
            }
            else
            {
                jumpForce -= 3;
            }
            jumpBuffer -= 1;
            movement.y = jumpForce;
        }
        controller.Move(movement * Time.deltaTime);
    }
}
