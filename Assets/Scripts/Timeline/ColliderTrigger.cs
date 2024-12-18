using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour
{
    [Header("Assign Object")]
    [Tooltip("Which object should be interacted with?")]
    [SerializeField] private GameObject colliderTriggerObject;

    [Header("Game Event")]
    [Tooltip("Which game event do we want our listener to respond to")]
    [SerializeField] private UnityEvent enterEvent;

/*    [Header("Game Event")]
    [Tooltip("Which game event do we want our listener to respond to")]
    [SerializeField] private UnityEvent exitEvent;*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            {
                enterEvent.Invoke();

                Debug.Log($"Collided with {gameObject.name}");
            }
    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            {
                exitEvent.Invoke();

                Debug.Log($"Is no longer collided with {gameObject.name}");
            }
    }*/
}
