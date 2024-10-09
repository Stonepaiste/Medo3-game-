using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _inputs;
    public int movespeed = 50;
    public float JumpVelocity = 5f;
    public bool _isjumping;
    private Vector3 velocity;
    public float jumpHeight = 2.4f;
    public float gravity = 9.81f;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnMove(InputValue value)
    {
        _inputs = value.Get<Vector2>();

        Vector3 direction = new Vector3(_inputs.x, 0, _inputs.y);
        GetComponent<CharacterController>().Move(transform.TransformDirection(direction) * Time.deltaTime * movespeed);

        if (GetComponent<CharacterController>().isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep the character grounded
        }

        velocity.y += gravity * Time.deltaTime;
        GetComponent<CharacterController>().Move(velocity * Time.deltaTime);
    }

    void OnJump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    /*
    void Update()
    {
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Move()
{
    Vector3 direction = new Vector3(_inputs.x, 0, _inputs.y);
    GetComponent<CharacterController>().Move(transform.TransformDirection(direction) * Time.deltaTime * movespeed);

    if (GetComponent<CharacterController>().isGrounded && velocity.y < 0)
    {
        velocity.y = -2f; // Small negative value to keep the character grounded
    }

    velocity.y += gravity * Time.deltaTime;
    GetComponent<CharacterController>().Move(velocity * Time.deltaTime);
}

public void Movement(InputAction.CallbackContext context)
{
    _inputs = context.ReadValue<Vector2>();
}*/

    /*private void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }*/

}
