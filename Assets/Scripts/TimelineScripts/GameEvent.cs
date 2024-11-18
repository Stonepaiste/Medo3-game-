using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    [Header("Game Events")]
    private List<GameEventListener> listeners = new List<GameEventListener>();


    public void RegisterListener(GameEventListener listener)     //Registers a listener and adds it to the list.
    { 
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)  //Removes the listener from the list.
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)        //For loop will go through the list of
        {                                                   //listeners and call the method OnEventRaised 
            listeners[i].OnEventRaised();                   //from GameEventListener script. 
        }                                                   //To avoid errors (index go out of range) it 
                                                            //loops through the list backwards.
    }

}
