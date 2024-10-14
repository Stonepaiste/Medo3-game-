using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerInput : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;
    [SerializeField] float movespeed = 500f;
    [SerializeField] float mouseSensitivity = 100f;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        float hAxis = movement.y;
        float vAxis = movement.x;

        Vector3 hMove = hAxis * transform.forward;
        Vector3 vMove = vAxis * transform.right;
        rb.velocity = (hMove + vMove).normalized * movespeed * Time.deltaTime;

        Debug.Log("Moving");
    }

    public void OnInteract(InputValue value)
    {

    }
}
