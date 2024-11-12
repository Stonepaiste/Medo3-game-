using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpAndDrop : MonoBehaviour
{
    public GameObject camera;
    public TextMeshProUGUI pickUpText;
    public TextMeshProUGUI interactText;
    //public Transform teleportDestination; // Set this to the new position in the Inspector
    //public ScreenFade screenFade; // Reference to the ScreenFade script
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
        /*if (Input.GetKeyDown("q") && isHolding) Drop();*/
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
            /*if (isHolding) Drop();*/
            itemCurrentlyHolding = itemInRange; // Set the item currently holding

            foreach (var c in itemCurrentlyHolding.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = false;
            foreach (var r in itemCurrentlyHolding.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = true;

            itemCurrentlyHolding.transform.parent = camera.transform;
            itemCurrentlyHolding.transform.localPosition = new Vector3(0.2f, -1f, 0.8f); // Position in front of the camera
            itemCurrentlyHolding.transform.localEulerAngles = new Vector3(0, -90, 0);

            pickUpText.gameObject.SetActive(false); // Hide the text after picking up
            isHolding = true;

            // Start teleport coroutine after picking up the object
            StopAllCoroutines(); // Stop any active coroutines to prevent overlap
            //StartCoroutine(TeleportWithFade());
        }

        /*IEnumerator TeleportWithFade()
        {
            yield return new WaitForSeconds(2f); // Wait for 2 seconds
            yield return StartCoroutine (screenFade.FadeOut()); // Start fade-out effect

            // Teleport player to the new position
            transform.position = teleportDestination.position;

            yield return StartCoroutine(screenFade.FadeIn()); // Fade back in after teleporting
        }*/


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
    
    /*void Drop()
    {
        if (itemCurrentlyHolding != null)
        {
            itemCurrentlyHolding.transform.parent = null;
            foreach (var c in itemCurrentlyHolding.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = true;
            foreach (var r in itemCurrentlyHolding.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = false;

            isHolding = false;

            RaycastHit hitDown;
            if (Physics.Raycast(transform.position, -Vector3.up, out hitDown))
            {
                itemCurrentlyHolding.transform.position = hitDown.point + new Vector3(transform.forward.x, 0, transform.forward.z);
            }

            itemCurrentlyHolding = null;
        }
    }
}
    */
