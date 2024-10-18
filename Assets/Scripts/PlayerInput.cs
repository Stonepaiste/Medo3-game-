using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float runSpeed = 200f;
    [SerializeField] float initialWalkSpeed = 100f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float sensitivityX = 100f;
    [SerializeField] float sensitivityY = 100f;

    Rigidbody rb;
    Transform player;
    Camera mainCamera;
    CinemachineVirtualCamera playerVirtualCamera;

    float walkSpeed;
    float movementX;
    float movementY;
    float lookX;
    float lookY;
    bool isRunning = false;
    Vector2 movement;


    void Awake()
    {
        //Removes hides cursor when playing
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        player = this.transform;
        mainCamera = Camera.main;
        playerVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        walkSpeed = initialWalkSpeed;
        isRunning = false;
        

    }

    private void FixedUpdate()
    {
        Move();
        Look();
        Run();
    }



    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        movementY = movement.y;
        movementX = movement.x;
    }

    public void OnRun(InputValue value)
    {
        isRunning = value.isPressed;
        Debug.Log(isRunning + "OnRun is working");
    }
    public void OnLook(InputValue value)
    {
        Vector2 look = value.Get<Vector2>().normalized;
        lookX = look.x;
        lookY = -look.y;
    }

    public void OnInteract(InputValue value)
    {

    }

    private void Move()
    {
        Vector3 move = new Vector3(movementX, 0f, movementY);
        Vector3 transformMove = transform.TransformVector(move);
        rb.velocity = transformMove * walkSpeed * Time.deltaTime;
    }

    void Look()
    {
        transform.Rotate(transform.up * lookX * rotationSpeed * Time.deltaTime); 
        playerVirtualCamera.transform.Rotate(Vector3.right * lookY * rotationSpeed * Time.deltaTime);
        Debug.Log("looking around");
    }

    void Run()
    {
        if (isRunning)
        {
            walkSpeed = runSpeed;
            Debug.Log(isRunning + "Run and isRunning is working");
        }
        else
        {
            Debug.Log("Set walkSpeed back to initialWalkSpeed");
            walkSpeed = initialWalkSpeed;
        }
    }
}
