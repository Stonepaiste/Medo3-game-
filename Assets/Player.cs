using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _inputs;
    public int movespeed = 50;
    public float gravity = -9.81f;
    private Vector3 velocity;

    private void Move()
    {
        Vector3 move = new Vector3(_inputs.x, 0, _inputs.y);
        GetComponent<CharacterController>().Move(transform.TransformDirection(move) * Time.deltaTime * movespeed);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        GetComponent<CharacterController>().Move(velocity * Time.deltaTime);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        _inputs = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}