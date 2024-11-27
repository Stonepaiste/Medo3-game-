using UnityEngine;

public class PadlockInteraction : MonoBehaviour
{
    public GameObject padlockCanvas;
    public Camera mainCamera;
    public PlayerInputHandler playerInputHandler;
    
    
    
    private bool isInRange = false; // Track if the player is within the trigger zone

    private void Start()
    {
        Cursor.visible = true;
        padlockCanvas.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            padlockCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q) && padlockCanvas.activeSelf)
        {
            padlockCanvas.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player is the one entering
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}

