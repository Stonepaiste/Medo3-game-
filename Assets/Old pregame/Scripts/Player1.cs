using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Vector2 _inputs;
    public int movespeed = 50;
    public float jumpHeight = 2.4f;
    public float gravity = 9.81f;
    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _inputs.x = Input.GetAxis("Horizontal"); // A/D or Left/Right
        _inputs.y = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 direction = new Vector3(_inputs.x, 0, _inputs.y);
        rb.MovePosition(transform.position + transform.TransformDirection(direction) * Time.deltaTime * movespeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * 2f * gravity), ForceMode.VelocityChange);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
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


