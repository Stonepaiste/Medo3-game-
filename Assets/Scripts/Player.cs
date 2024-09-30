using System;
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
   // private Vector3 velocity;
    //public float jumpHeight = 2.4f;

    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    private Rigidbody _rb;
    

    private void Move()
    {
        Vector3 move = new Vector3(_inputs.x, _inputs.y);
        GetComponent<CharacterController>().Move(transform.TransformDirection(move) * Time.deltaTime * movespeed);

        // Apply gravity
      //  velocity.y += gravity * Time.deltaTime;
       // GetComponent<CharacterController>().Move(velocity * Time.deltaTime);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        _inputs = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Move();
        _isjumping |= Input.GetKeyDown(KeyCode.Space);
        {
            
        }

    }

    private void FixedUpdate()
    {
       // if (Keyboard.current.spaceKey.wasPressedThisFrame) 
        //{
         //   velocity.y = Mathf.Sqrt(2f  * 1.5f);
        //}
        if (_isjumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
            
        }

       
        _isjumping = false;
    
    }
    
    
   
}