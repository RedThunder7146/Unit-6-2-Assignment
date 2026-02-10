using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movementscript : MonoBehaviour
{
    [Header("References")]
    private CharacterController characterController;
    public ThirdPersonCamera thirdPersonCamera;
    [Header("Movement settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpHeight = 2f;

    private float verticalVelocity;

    [Header("Input actions")]

    InputAction moveAction;
    InputAction jumpAction;


    [Header("Input")]
    public float moveInput;
    public float turnInput;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }
    private void Update()
    {
        InputManagement();
        Movement();
    }

    private void Movement()
    {
        GroundMovement();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(turnInput, 0, moveInput);

        print(turnInput + " " + moveInput);

        move.y = VerticalForceCalculation();


        characterController.Move(thirdPersonCamera.moveDir.normalized* walkSpeed*Time.deltaTime);
    }

    private float VerticalForceCalculation()
    {
        if(characterController.isGrounded)
        {
            verticalVelocity = -1f;

            if (Input.GetButton("Jump"))
            {
                verticalVelocity = MathF.Sqrt(jumpHeight * gravity * 2);
            }
        }

        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }


    private void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

    }
    
}
