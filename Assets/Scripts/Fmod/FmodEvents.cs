using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{
    //This script is used to store all the FMOD events that are used in the game.
    //We create a public static instance of the FmodEvents script so that we can access it from anywhere in the game.
    //We also create a private set so that we can only set the instance in this script.
    //We then create a private Awake method that checks if the instance is not null and if it is it will log an error message.
    [field: Header("Ocean sound")]
    [field: SerializeField] public EventReference Ocean { get; private set; }
    
    //We then create a public static instance of the FmodEvents script so that we can access it from anywhere in the game.
    public static FmodEvents instance { get; private set; }
   
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events scripts in the scene");
        }
       
        instance = this;
    }
}