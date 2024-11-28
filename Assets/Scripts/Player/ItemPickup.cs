using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using FMOD.Studio;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public string itemName;  // Name of the item (e.g., "book" or "glasses")
    public bool isInteractable;
    public float rotationSpeed = 50;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public GameObject paperCanvas;  // Canvas for paper background and text
    public TextMeshProUGUI paperText;  // Text element for the message
    public bool isRotating = false;
    public EventInstance _BookMonologue;
    public EventInstance _GlassesMonologue;

    bool book = false;
    bool glasses = true;

    [SerializeField] float typingDelay = 0.03f;  // Delay between each letter appearing
    private bool isTyping = false;  // Flag to check if typing is ongoing

    private void Awake()
    {
        paperCanvas = FindObjectOfType<MemoryCanvas>().gameObject;
        paperText = paperCanvas.GetComponentInChildren<TextMeshProUGUI>();
        itemName = gameObject.name;
    }


    void Start()
    {
        isInteractable = false;
        if (virtualCamera != null)
        {
            virtualCamera.enabled = false;
        }

        if (paperCanvas != null)
        {
            paperCanvas.GetComponentInChildren<Image>().enabled = false;
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
            isInteractable = true;
        }
    }

    private void HandleItemInteraction()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            isRotating = true;
            TurnOnVirtualCamera();

            if (paperCanvas != null)
            {
                paperCanvas.GetComponentInChildren<Image>().enabled = true;
                StartCoroutine(DisplayTextAfterRotation());
            }
        }
    }

    private IEnumerator DisplayTextAfterRotation()
    {
        // Wait for a brief moment to simulate camera settling
        yield return new WaitForSeconds(1f); // Adjust this delay as needed

        // Determine which message to display based on the item name
        if (itemName == "Glasses")
        {
            paperText.text = "Today was the worst. At lunch, they kept staring and laughing, whispering like I couldn’t tell it was about me. In the hall after, one of them shoved me, and my glasses flew off. I barely had time to pick them up before someone stepped on them. They just laughed, calling me a nerd. I don't have any friends and I'm always by myself. I wish I had someone to talk to.";
            _GlassesMonologue.start();
        }
        else
        {
            paperText.text = "Date: 30/06\nDear diary\nI’m sitting alone in my room after a long day. It was my grandmoms funeral. I already miss every moment with her. She was the one holding me together after the other kids bullied me. She was the only person who understood me. I really miss her and I feel so lost without her.";
            _BookMonologue.start();
        }
        // Start typing out the message
        StartCoroutine(TypeText(paperText.text));
    }

    private IEnumerator TypeText(string message)
    {
        paperText.enabled = true;
        paperText.text = "";  // Clear any existing text
        isTyping = true;

        foreach (char letter in message)
        {
            paperText.text += letter;  // Add each letter one by one
            yield return new WaitForSeconds(typingDelay);
        }

        isTyping = false;
        yield return new WaitForSeconds(2f);
        paperText.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInteractable = false;
        }
    }

    private void DisableCanvasWithQ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isRotating = false;
            TurnOffVirtualCamera();
            _GlassesMonologue.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            _BookMonologue.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

            if (paperCanvas != null)
            {
                paperCanvas.GetComponentInChildren<Image>().enabled = false;
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

