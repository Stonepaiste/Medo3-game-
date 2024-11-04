using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitchHandle : MonoBehaviour
{
    public Transform handle; // Reference to the handle Transform
    public float handleDownRotation = -45f; // Adjust this based on how far you want the handle to go down
    public float rotationSpeed = 5f; // Speed of the handle movement
    private bool playerIsClose = false; // Track if the player is in range
    private bool handleIsDown = false; // Track if the handle is down

    void Update()
    {
        // Check if player is close and presses the "E" key
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            handleIsDown = !handleIsDown; // Toggle handle state when "E" is pressed
        }

        // Rotate the handle based on the current state
        if (handleIsDown)
        {
            // Rotate the handle to the "down" position
            Quaternion targetRotation = Quaternion.Euler(handleDownRotation, handle.localEulerAngles.y, handle.localEulerAngles.z);
            handle.localRotation = Quaternion.Lerp(handle.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            // Rotate the handle back to its original "up" position
            Quaternion originalRotation = Quaternion.identity; // Assuming zero rotation is the starting position
            handle.localRotation = Quaternion.Lerp(handle.localRotation, originalRotation, Time.deltaTime * rotationSpeed);
        }
    }

    // Trigger when player enters the switch area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true; // Enable "E" key interaction when player is close
        }
    }

    // Trigger when player leaves the switch area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false; // Disable "E" key interaction when player leaves
        }
    }
}