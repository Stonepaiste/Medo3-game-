using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerInpuController : MonoBehaviour
{
    [Header("Movement Speed")]
    [Tooltip("How fast you want to walk.")]
    [SerializeField] float initialWalkSpeed = 100f;
    [Tooltip("How fast you want to run.")]
    [SerializeField] float runSpeed = 300f;
    [Header("Camera Sensitivity")]
    [Tooltip("The sensitivity for the horizontal camera movement.")]
    [SerializeField] float sensitivityX = 200f;
    [Tooltip("The sensitivity for the vertical camera movement.")]
    [SerializeField] float sensitivityY = 200f;
    [Header("Pick Up Items")]
    [Tooltip("How far away the character should be before being able to pick up something")]
    [SerializeField] float distanceToObject = 100f; 

    Rigidbody rb;
    CinemachineVirtualCamera playerVirtualCamera;

    float walkSpeed;
    float movementX;
    float movementY;
    float lookX;
    float lookY;
    bool isRunning = false;
    bool isHit = false;
    int interactable = 1 << 6;

    Vector2 movement;
    RaycastHit hit;

    void Awake()
    {
        //Hides cursor when playing
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        //Gets the rigidbody from the gameobject where the script is attached
        rb = GetComponent<Rigidbody>();

        //Gets the cinemachine virtual camera from a child gameobject
        playerVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();

        //sets the walkspeed to initialWalkspeed
        walkSpeed = initialWalkSpeed;

        //sets the bool isRunning to false
        isRunning = false;
    }

    private void Update()
    {
        Run();
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }

    //InputSystem method for "Move" in inputsystem action asset
    public void OnMove(InputValue value)
    {
        //Getting the value of button pressed from the inputsystem and storing it in 
        movement = value.Get<Vector2>();
        movementY = movement.y;
        movementX = movement.x;
    }

    public void OnRun(InputValue value)
    {
        isRunning = value.isPressed;
        Debug.Log(isRunning + " OnRun is working");
    }

    public void OnLook(InputValue value)
    {
        Vector2 look = value.Get<Vector2>().normalized;
        lookX = look.x;
        lookY = -look.y;
    }

    public void OnInteract(InputValue value)
    {
        Interact();
        
    }

    private void Move()
    {
        Vector3 move = new Vector3(movementX, 0f, movementY);
        Vector3 transformMove = transform.TransformVector(move);
        rb.velocity = transformMove * walkSpeed * Time.deltaTime;
        
    }

    void Run()
    {
        if (isRunning)
        {
            walkSpeed = runSpeed;
            Debug.Log(isRunning + " Set walkSpeed to runSpeed");
        }
        else
        {
            Debug.Log("Set walkSpeed back to initialWalkSpeed");
            walkSpeed = initialWalkSpeed;
        }
    }

    void Look()
    {
        transform.Rotate(transform.up * lookX * sensitivityX * Time.deltaTime); 
        playerVirtualCamera.transform.Rotate(Vector3.right * lookY * sensitivityY * Time.deltaTime);
        Debug.Log("Looking around");
    }

    void Interact()
    {
        
        isHit = Physics.Raycast(transform.position, transform.forward, out hit, distanceToObject, interactable);
        if (isHit)
        {
            Debug.Log(hit.point);
            Debug.Log("Pick up");
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
