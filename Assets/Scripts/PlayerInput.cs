using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerInput : MonoBehaviour
{
    Transform player;
    Transform camera; 
    Vector2 movement;
    float movementX;
    float movementY;
    Rigidbody rb;
    [SerializeField] float walkSpeed = 100f;
    [SerializeField] float runSpeed = 200f;
    [SerializeField] float sensitivityX = 100f;
    [SerializeField] float sensitivityY = 100f;
    [SerializeField] float lookX;
    [SerializeField] float lookY;
    bool isRunning = false; 


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        player = this.transform;
        camera = Camera.main.transform;

    }

    private void FixedUpdate()
    {
        Move();
        //Look();
    }



    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        movementY = movement.y;
        movementX = movement.x;
    }

    public void OnLook(InputValue value)
    {
        lookX += value.Get<Vector2>().x * sensitivityX * player.rotation.y;
        lookY -= value.Get<Vector2>().y * sensitivityY;
        Debug.Log("looking");
    }

    public void OnInteract(InputValue value)
    {

    }

    private void Move()
    {
        Vector3 move = new Vector3(movementX, 0f, movementY);
        rb.velocity = move * walkSpeed * Time.deltaTime;
    }

    private void Look()
    {
        Debug.Log("Looking around");
        Vector3 lookXAxis = new Vector3(player.rotation.y + lookX, 0f, 0f);
        Vector3 lookYAxis = new Vector3(0f, camera.rotation.x + lookY, 0f);
        //camera.transform.rotation = Quaternion.Euler(camera.transform.rotation.x + lookY, 0, 0);
    }
}
