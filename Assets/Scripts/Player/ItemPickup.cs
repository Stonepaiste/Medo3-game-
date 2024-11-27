using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using FMOD.Studio;
using System.Security.Cryptography.X509Certificates;

public class ItemPickup : MonoBehaviour
{
    public string itemName;  // Name of the item (e.g., "book" or "glasses")
    public bool isInteractable;
    public float rotationSpeed = 50;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public GameObject pushE;
    public GameObject pushQ;
    public GameObject paperCanvas;  // Canvas for paper background and text
    public TextMeshProUGUI paperText;  // Text element for the message
    public bool isRotating = false;
    public EventInstance _BookMonologue;
    public EventInstance _GlassesMonologue;

    public float typingDelay = 0.05f;  // Delay between each letter appearing
    private bool isTyping = false;  // Flag to check if typing is ongoing


    private void Awake()
    {
        //pushE = GameObject.Find("press E to see");
        pushQ = GameObject.Find("Press ESC to leave");
    }

    void Start()
    {
        isInteractable = false;
        //pushE.SetActive(false);
        //pushQ.SetActive(false);

        if (virtualCamera != null)
        {
            virtualCamera.enabled = false;
        }

        if (paperCanvas != null)
        {
            paperCanvas.SetActive(false);
        }
        
        _BookMonologue = RuntimeManager.CreateInstance(FmodEvents.Instance.BookMonologue);
        _GlassesMonologue = RuntimeManager.CreateInstance(FmodEvents.Instance.GlassesMonologue);
        
    }

    void Update()
    {
        HandleItemInteraction();
        DisableCanvasWithQ();

        if (isRotating)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //pushE.SetActive(true);
            isInteractable = true;
        }
    }

    private void HandleItemInteraction()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            isRotating = true;
            TurnOnVirtualCamera();
            //pushE.SetActive(false);
            //pushQ.SetActive(true);

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
            paperText.text = "Date: 30/06\nDear diary\nI’m sitting alone in my room after a long day. It was my grandmoms funeral. I already miss every moment with her. She was the one holding me together after the other kids bullied me. She was the only person who understood me. I really miss her and I feel so lost without her.";
            _BookMonologue.start();
        }
        else if (itemName == "Glasses")
        {
            paperText.text = "Today was the worst. At lunch, they kept staring and laughing, whispering like I couldn’t tell it was about me. In the hall after, one of them shoved me, and my glasses flew off. I barely had time to pick them up before someone stepped on them. They just laughed, calling me a nerd. I don't have any friends and I'm always by myself. I wish I had someone to talk to.";
            _GlassesMonologue.start();
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
            //pushE.SetActive(false);
        }
    }

    private void DisableCanvasWithQ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isRotating = false;
            TurnOffVirtualCamera();
            //pushQ.SetActive(false);
            _GlassesMonologue.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            _BookMonologue.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

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

