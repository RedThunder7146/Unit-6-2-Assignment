using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movementscript : MonoBehaviour
{
    [Header("References")]
    private CharacterController characterController;
    [SerializeField] private Transform cam;
    [Header("Movement settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float turningSpeed = 2f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] public Animator anim;

    private float verticalVelocity;

    [Header("Input actions")]

    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;


    [Header("Input")]
    public float moveInput;
    public float turnInput;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
    }
    private void Update()
    {

        Movement();
    }

    private void Movement()
    {
        GroundMovement();
        Turn();
    }

    private void GroundMovement()
    {

        Vector3 moveValue = moveAction.ReadValue<Vector3>();
        Vector3 move = new Vector3(turnInput, 0, moveInput);


        moveValue.y = VerticalForceCalculation();




        characterController.Move(moveValue* walkSpeed*Time.deltaTime);
    }

    private void Turn()
    {
        
        Vector2 currentLookDirection = lookAction.ReadValue<Vector2>();
        currentLookDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turningSpeed);
        
        
    }

    private float VerticalForceCalculation()
    {
        if(characterController.isGrounded)
        {

            print("Is grounded");
            verticalVelocity = -1f;

            if (jumpAction.IsPressed())
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



    
}
