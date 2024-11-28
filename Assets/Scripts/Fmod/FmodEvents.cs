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
    
    [field: Header("DoorEhouse")]
    [field: SerializeField] public EventReference DoorEhouse { get; private set; }
    
    [field: Header("Enemy1SoundWEAK")]
    [field: SerializeField] public EventReference Enemy1SoundWEAK { get; private set; }
    
    [field: Header("Enemy1SoundREMEMBER")]
    [field: SerializeField] public EventReference Enemy1SoundREMEMBER { get; private set; }
    
    [field: Header("EnemySoundALONE")]
    [field: SerializeField] public EventReference EnemySoundALONE { get; private set; }
    
    [field: Header("LightSwitch")]
    [field: SerializeField] public EventReference LightSwitch { get; private set; }
    
    [field: Header("BookMonologue")]
    [field: SerializeField] public EventReference BookMonologue { get; private set; }
    
    [field: Header("GlassesMonologue")]
    [field: SerializeField] public EventReference GlassesMonologue { get; private set; }
    
    [field: Header("Enginefail")]
    [field: SerializeField] public EventReference Enginefail { get; private set; }
    
    [field: Header("INeedFuel")]
    [field: SerializeField] public EventReference INeedFuel { get; private set; }
    
    [field: Header("AlexAreYouOkay")]
    [field: SerializeField] public EventReference AlexAreYouOkay { get; private set; }
    
    [field: Header("What is up with this power")]
    
    [field: SerializeField] public EventReference WhatIsUpWithThisPower { get; private set; }
    
    [field: Header("EnemiesSoundMulti")]
		[field: SerializeField] public EventReference EnemiesSoundMulti { get; private set; }	
    
    [field: Header("EndEnemysMulti")]
    		[field: SerializeField] public EventReference EndEnemysMulti { get; private set; }
    
    [field: Header("SomethingAboutThatVoice")]
    [field: SerializeField] public EventReference SomethingAboutThatVoice { get; private set; }
    // All dialogue are played through FMOD eventEmitter in SOUNDDIALOGUE COMPONENT USING TIMELINE
    
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