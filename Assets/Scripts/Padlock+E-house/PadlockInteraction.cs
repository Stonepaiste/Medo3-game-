using UnityEngine;

public class PadlockInteraction : MonoBehaviour
{
    public GameObject padlockCanvas;
    public Camera mainCamera;
    public PlayerInputHandler playerInputHandler;
    GameObject itemInRange; // Store the item in the trigger range

    private void Start()
    {
        Cursor.visible = true;
        padlockCanvas.SetActive(false);
    }

    private void Update()
    {
        if (itemInRange != null && Input.GetKeyDown("e"))
             {
            padlockCanvas.SetActive(true);
                    playerInputHandler.enabled = false;
                    //Time.timeScale = 0;
             }
        if (Input.GetKeyDown(KeyCode.Escape) && padlockCanvas.activeSelf)
        {
            padlockCanvas.SetActive(false);
            playerInputHandler.enabled = true;
            //Time.timeScale = 1;
        }
    }
        
}
