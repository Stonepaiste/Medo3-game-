using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

//This script is used to create methoods for FMOD Events from the FMODEvents script so the enemy can activate it when the player enters. 
public class EnemySpeak : MonoBehaviour
{
    
    [SerializeField] private FmodEvents fmodEvents; //Reference to the FmodEvents script.
    private EventInstance _enemyWEAK; //The event instance for the enemy sound.
    private EventInstance _enemyREMEMBER; //The event instance for the enemy sound.
    private EventInstance _enemyALONE; //The event instance for the enemy sound.
    private bool weakHasPlayed = false; //Bool to check if the weak sound has played.
    private bool rememberHasPlayed = false; //Bool to check if the remember sound has played.
    private bool aloneHasPlayed = false; //Bool to check if the alone sound has played.
    
    private void Start()
    {
        //Create the event instances for the enemy sounds.
        _enemyWEAK = RuntimeManager.CreateInstance(fmodEvents.Enemy1SoundWEAK);
        _enemyWEAK.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        
        _enemyREMEMBER = RuntimeManager.CreateInstance(fmodEvents.Enemy1SoundREMEMBER);
        _enemyREMEMBER.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        
        _enemyALONE = RuntimeManager.CreateInstance(fmodEvents.EnemySoundALONE);
        _enemyALONE.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
    }
    
    // Start is called before the first frame update
    public void EnemyWeak()
    {
        if (weakHasPlayed == false && rememberHasPlayed == false && aloneHasPlayed == false)
        {
            //Start the enemy sound for the weak state.
            _enemyWEAK.start();
            weakHasPlayed = true;
        }
        
    }
    
    public void EnemyRemember()
    {
        if (weakHasPlayed==true && rememberHasPlayed==false && aloneHasPlayed==false)
        {
            //Start the enemy sound for the remember state.
            _enemyREMEMBER.start();
            rememberHasPlayed = true;
        }
        
    }
    
    public void EnemyAlone()
    {
        if(weakHasPlayed==true && rememberHasPlayed==true && aloneHasPlayed==false)
        {
            //Start the enemy sound for the alone state.
            _enemyALONE.start();
            aloneHasPlayed = true;
        }
       
    }
    
}
