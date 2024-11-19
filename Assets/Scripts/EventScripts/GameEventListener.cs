using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Header("Game Event reference")]
    [Tooltip("Drag and drop the reference that needs to listened and responded to.")]
    [SerializeField] private GameEvent Event;

    [Header("Response")]
    [Tooltip("What respone is given when listened to a reference.")]
    [SerializeField] private UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);       //Method which will add a listener to the list in GameEvent script by passing this class.
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);    //In this method the listener will be removed from the list.
    }

    public void OnEventRaised() 
    {
        Response.Invoke();                //Invoke UnityEvent
    }
}
