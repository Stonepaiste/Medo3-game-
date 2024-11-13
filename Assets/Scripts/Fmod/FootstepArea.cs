using System;
using System.Collections;
using System.Collections;
using UnityEngine;

public class FootstepArea : MonoBehaviour
{
    public bool isInside; // Set this to true if this area is inside


    private void Start()
    {
        isInside = true;
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