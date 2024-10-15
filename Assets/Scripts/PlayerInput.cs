using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float walkSpeed = 100f;
    [SerializeField] float runSpeed = 200f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float sensitivityX = 100f;
    [SerializeField] float sensitivityY = 100f;

    Rigidbody rb;
    Transform player;
    Camera mainCamera;
    CinemachineVirtualCamera playerVirtualCamera;

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
        

    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }



    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        movementY = movement.y;
        movementX = movement.x;
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
}
