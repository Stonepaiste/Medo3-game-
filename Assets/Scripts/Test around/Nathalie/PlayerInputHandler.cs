using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Movement Speed")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    [Header("Gravity Value")]
    [SerializeField] private float gravityValue;

    Vector2 movePlayer;
    bool runPlayer = false;
    float moveSpeed;

    private CharacterController controller;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Transform cameraTransform;


    private void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        moveSpeed = walkSpeed;

        cameraTransform = Camera.main.transform;


    }
    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        Vector2 movement = movePlayer;
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        move.Normalize();
        controller.Move(move * Time.deltaTime * walkSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnMove(InputValue value) 
    {
        movePlayer = value.Get<Vector2>().normalized;
    }

    void OnRun(InputValue value)
    {
        runPlayer = value.isPressed;

        Debug.Log("Run is pressed");

      if (runPlayer = value.isPressed)
        {
            runPlayer = true;
            moveSpeed = runSpeed;

            Debug.Log("I am runniiing");
        }
      else if (runPlayer != value.isPressed)
        {
            runPlayer = false;

            Debug.Log("I am walking again");
        }
     
  
  
    }
}
