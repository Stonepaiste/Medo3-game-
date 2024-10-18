using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interaction currentInteraction;


    void Update()
    {
        CheckInteraction();

        if (Input.GetKeyDown(KeyCode.F) && currentInteraction != null)
        {
            currentInteraction.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interaction")
            {
                Interaction newInteraction = hit.collider.GetComponent<Interaction>();

                if (currentInteraction && newInteraction != currentInteraction )
                {
                    currentInteraction.DisableOutline();
                }

                if (newInteraction.enabled)
                {
                    SetNewCurrentInteraction(newInteraction);
                }
                else
                {
                    DisableCurrentInteraction();
                }
            }
            else
            {
                DisableCurrentInteraction();
            }
        }
        else
        {
            DisableCurrentInteraction();
        }
    }

    void SetNewCurrentInteraction(Interaction newInteraction)
    {
         currentInteraction = newInteraction;
         currentInteraction.EnableOutline();
    }

    void DisableCurrentInteraction()
    {
        if (currentInteraction)
        {
            currentInteraction.DisableOutline();
            currentInteraction = null;
        }
    }
}
