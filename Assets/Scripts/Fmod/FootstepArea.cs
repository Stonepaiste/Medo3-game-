using System;
using System.Collections;
using System.Collections;
using UnityEngine;

public class FootstepArea : MonoBehaviour
{
    public bool isInside; // Set this to true if this area is inside


    private void Start()
    {
        // Check if the player is already inside the collider at the start
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerInputHandler player = collider.GetComponent<PlayerInputHandler>();
                if (player != null)
                {
                    player.SetFootstepArea(isInside);
                    Debug.Log("Player started inside the area, footstep area set to: " + isInside);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the area");
            PlayerInputHandler player = other.GetComponent<PlayerInputHandler>();
            if (player != null)
            {
                player.SetFootstepArea(isInside);
                Debug.Log("Footstep area set to: " + isInside);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the area");
            PlayerInputHandler player = other.GetComponent<PlayerInputHandler>();
            if (player != null)
            {
                player.SetFootstepArea(!isInside);
                Debug.Log("Footstep area set to: " + !isInside);
            }
        }
    }
}