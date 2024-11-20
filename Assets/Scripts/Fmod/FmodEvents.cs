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
    
    [field: Header("Footstep sounds")]
    [field: SerializeField] public EventReference FootstepsForest { get; private set; }
    
    [field: Header("Foodsteps wood")]
    [field: SerializeField] public EventReference FootstepsWood { get; private set; }
    
    [field: Header("ForestSound")]
    [field: SerializeField] public EventReference ForestSound { get; private set; }
    
    [field: Header("Treewind")]
    [field: SerializeField] public EventReference Treewind { get; private set; }
    
    [field: Header("Music")]
    [field: SerializeField] public EventReference Music { get; private set; }
    
    [field: Header("FlashlightOn")] 
    [field: SerializeField] public EventReference FlashlightOn { get; private set; }
    
    [field: Header("FlashlightOff")]
    [field: SerializeField] public EventReference FlashlightOff { get; private set; }

	[field: Header("RainThunder")]
	[field: SerializeField] public EventReference RainThunder { get; private set; }
	
	[field: Header("PadlockButtons")]
	[field: SerializeField] public EventReference PadlockButtons { get; private set; }

	[field: Header("PadlockCorrect")]
	[field: SerializeField] public EventReference PadlockCorrect { get; private set; }
    
	[field: Header("PadlockIncorrect")]
	[field: SerializeField] public EventReference PadlockIncorrect { get; private set; }
	
	[field: Header("Thunder")]
	[field: SerializeField] public EventReference Thunder { get; private set; }
	
    //All dialogue are played through FMOD eventEmitter in SOUNDDIALOGUE COMPONENT USING TIMELINE
    
    //We then create a public static instance of the FmodEvents script so that we can access it from anywhere in the game.
    public static FmodEvents Instance { get; private set; }
   
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one FMOD Events scripts in the scene");
        }
       
        Instance = this;
    }
}