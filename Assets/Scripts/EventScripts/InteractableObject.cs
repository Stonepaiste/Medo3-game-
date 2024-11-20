using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    [Header("Assign Object")]
    [Tooltip("Which object should be interacted with?")]
    [SerializeField] private GameObject interactableObject;

   /* [Header("Text")]
    [Tooltip("Which text should be shown when close to object")]
    [SerializeField] private TextMeshProUGUI interactText;*/

    [Header("Game Event")]
    [Tooltip("Which game event do we want our listener to respond to")]
    [SerializeField] private UnityEvent whatEvent;

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactText.enabled = true;

            Debug.Log("Interaction text is shown");
        }
    }*/
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.SetActive(true);

            whatEvent.Invoke();

            Debug.Log("Switch is clicked");
        }
    }

}
