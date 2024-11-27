using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using TMPro;

public class PickUpAndDrop : MonoBehaviour
{
    public GameObject camera;
    public TextMeshProUGUI pickUpText;
    public TextMeshProUGUI interactText;
    public CinemachineBrain playerPOVCamera;

    public Vector3 itemPositionOffset = new Vector3(0.2f, -1f, 0.8f); // Offset for item position
    public Vector3 itemRotationOffset = new Vector3(0, -90, 0); // Offset for item rotation

    float maxPickupDistance = 5;
    GameObject itemCurrentlyHolding;
    GameObject itemInRange; // Store the item in the trigger range
    bool isHolding = false;
    bool canInteractToDisappear = false; // Track if player is in specific trigger zone

    public bool FuelCanDropped { get; private set; } = false;

    void Start()
    {
        pickUpText.gameObject.SetActive(false); // Hide the pickup text initially
    }

    void Update()
    {
        if (itemInRange != null && Input.GetKeyDown("e")) Pickup(); // Pick up the item in range
        if (canInteractToDisappear && Input.GetKeyDown("e")) MakeFuelCanDisappear(); // Press "I" to make can disappear

        if (isHolding && itemCurrentlyHolding != null)
        {
            itemCurrentlyHolding.transform.position = playerPOVCamera.transform.position + playerPOVCamera.transform.TransformDirection(itemPositionOffset); // Update the item's position with offset
            itemCurrentlyHolding.transform.rotation = playerPOVCamera.transform.rotation * Quaternion.Euler(itemRotationOffset); // Update the item's rotation with offset
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item") && !isHolding)
        {
            Debug.Log("Text Display");
            itemInRange = other.gameObject; // Store the reference of the item in range
            pickUpText.gameObject.SetActive(true); // Show the text when near an item
        }
        else if (isHolding && other.CompareTag("Interact")) // Specific collider check
        {
            interactText.gameObject.SetActive(true); // Show "Press I to drop" text
            canInteractToDisappear = true; // Allow player to press "I" to drop
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item") && !isHolding)
        {
            itemInRange = null; // Clear the reference when leaving the range
            pickUpText.gameObject.SetActive(false); // Hide the text when out of range
        }
        else if (isHolding && other.CompareTag("Interact"))
        {
            interactText.gameObject.SetActive(false); // Hide the interact text when exiting
            canInteractToDisappear = false; // Disable interaction when out of range
        }
    }

    void Pickup()
    {
        if (itemInRange != null)
        {
            itemCurrentlyHolding = itemInRange; // Set the item currently holding

            foreach (var c in itemCurrentlyHolding.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = false;
            foreach (var r in itemCurrentlyHolding.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = true;

            itemCurrentlyHolding.transform.parent = camera.transform;
            itemCurrentlyHolding.transform.localPosition = itemPositionOffset; // Position in front of the camera
            itemCurrentlyHolding.transform.localEulerAngles = itemRotationOffset;
            pickUpText.gameObject.SetActive(false); // Hide the text after picking up
            isHolding = true;
        }
    }

    void MakeFuelCanDisappear()
    {
        if (itemCurrentlyHolding != null)
        {
            Destroy(itemCurrentlyHolding); // Remove the fuel can
            itemCurrentlyHolding = null;
            isHolding = false;
            interactText.gameObject.SetActive(false); // Hide interact text after dropping
            canInteractToDisappear = false; // Reset interaction flag

            FuelCanDropped = true;
        }
    }
}