using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockInteraction : MonoBehaviour
{
    public GameObject padlockCanvas;

    private void Start()
    {
        padlockCanvas.SetActive(false);
    }

    private void Update()
    {
        // Check for a left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits this game object (the padlock), open the canvas
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                padlockCanvas.SetActive(true);
                //Time.timeScale = 0f; // Pause the game
            }
        }

        // Optional: Close the canvas with a specific key (e.g., "Escape")
        if (Input.GetKeyDown(KeyCode.Escape) && padlockCanvas.activeSelf)
        {
            padlockCanvas.SetActive(false);
            //Time.timeScale = 1f; // Resume the game
        }
    }
}
