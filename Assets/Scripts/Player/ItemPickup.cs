using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public string itemName;  // Name of the item (e.g., "book" or "glasses")
    public bool isInteractable;
    public float rotationSpeed = 50;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public GameObject pushE;
    public GameObject pushEsc;
    public GameObject paperCanvas;  // Canvas for paper background and text
    public TextMeshProUGUI paperText;  // Text element for the message
    public bool isRotating = false;

    public float typingDelay = 0.05f;  // Delay between each letter appearing
    private bool isTyping = false;  // Flag to check if typing is ongoing

    void Start()
    {
        isInteractable = false;
        pushE.SetActive(false);
        pushEsc.SetActive(false);

        if (virtualCamera != null)
        {
            virtualCamera.enabled = false;
        }

        if (paperCanvas != null)
        {
            paperCanvas.SetActive(false);
        }
    }

    void Update()
    {
        HandleItemInteraction();
        DisableCanvasWithEscape();

        if (isRotating)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pushE.SetActive(true);
            isInteractable = true;
        }
    }

    private void HandleItemInteraction()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            isRotating = true;
            TurnOnVirtualCamera();
            pushE.SetActive(false);
            pushEsc.SetActive(true);

            if (paperCanvas != null)
            {
                paperCanvas.SetActive(true);
                StartCoroutine(DisplayTextAfterRotation());
            }
        }
    }

    private IEnumerator DisplayTextAfterRotation()
    {
        // Wait for a brief moment to simulate camera settling
        yield return new WaitForSeconds(1f); // Adjust this delay as needed

        // Determine which message to display based on the item name
        if (itemName == "Book")
        {
            paperText.text = "30/06\nDear diary\nIm sitting alone in my room after a long day. It was my grandmoms funeral. I cant stop smiling when i think about the moments when we used to go to the lake house and pick flowers for the kitchen. She was the only person who understood me. I miss her everyday and I feel so lost without her";
        }
        else if (itemName == "Glasses")
        {
            paperText.text = "Today was the worst. At lunch, they kept staring and laughing, whispering like I couldn’t tell it was about me. In the hall after, one of them shoved me, and my glasses flew off. I barely had time to pick them up before someone stepped on them. They just laughed, calling me a nerd. I don't have any friends and I'm always by myself. I wish I had someone to talk to";
        }

        // Start typing out the message
        StartCoroutine(TypeText(paperText.text));
    }

    private IEnumerator TypeText(string message)
    {
        paperText.text = "";  // Clear any existing text
        isTyping = true;

        foreach (char letter in message)
        {
            paperText.text += letter;  // Add each letter one by one
            yield return new WaitForSeconds(typingDelay);
        }

        isTyping = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInteractable = false;
            pushE.SetActive(false);
        }
    }

    private void DisableCanvasWithEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isRotating = false;
            TurnOffVirtualCamera();
            pushEsc.SetActive(false);

            if (paperCanvas != null)
            {
                paperCanvas.SetActive(false);
            }
        }
    }

    public void TurnOnVirtualCamera()
    {
        if (virtualCamera != null)
        {
            virtualCamera.enabled = true;
        }
    }

    public void TurnOffVirtualCamera()
    {
        if (virtualCamera != null)
        {
            virtualCamera.enabled = false;
        }
    }
}

