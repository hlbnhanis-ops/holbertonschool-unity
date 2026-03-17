using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 basePos;
    // Input Actions References
    InputAction moveAction;
    InputAction jumpAction;

    private float verticalVelocity;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpPower = 5f;

    [SerializeField]
    private readonly int speed = 5;

    // Character Controller
    CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basePos = transform.position;
        controller = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
void Update()
{

    if(transform.position.y < -10)
    {
        transform.position = basePos;
        return;
    }

    Vector2 moveValue = moveAction.ReadValue<Vector2>();

    // 🎯 Mouvement horizontal
    Vector3 horizontalMove =
        transform.forward * moveValue.y +
        transform.right   * moveValue.x;

    horizontalMove *= speed;

    // 🎯 Gestion du sol
    if (controller.isGrounded)
    {
        if (verticalVelocity < 0)
            verticalVelocity = -2f; // petit ancrage au sol

        if (jumpAction.IsPressed())
        {
            verticalVelocity = jumpPower;
        }
    }

    // 🎯 Gravité
    verticalVelocity += gravity * Time.deltaTime;

    // 🎯 Mouvement final
    Vector3 movement = horizontalMove;
    movement.y = verticalVelocity;

    controller.Move(movement * Time.deltaTime);
}

}
