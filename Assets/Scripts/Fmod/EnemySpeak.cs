using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

//This script is used to create methoods for FMOD Events from the FMODEvents script so the enemy can activate it when the player enters. 
public class EnemySpeak : MonoBehaviour
{
    
    //[SerializeField] private FmodEvents fmodEvents; //Reference to the FmodEvents script.
    //private EventInstance _enemyWEAK; //The event instance for the enemy sound.
    //private EventInstance _enemyREMEMBER; //The event instance for the enemy sound.
    //private EventInstance _enemyALONE; //The event instance for the enemy sound.
    private EventInstance _enemymulti; 
    //private bool weakHasPlayed = false; //Bool to check if the weak sound has played.
    //private bool rememberHasPlayed = false; //Bool to check if the remember sound has played.
    //private bool aloneHasPlayed = false; //Bool to check if the alone sound has played.
    
    private void Start()
    {
        //Create the event instances for the enemy sounds.
       /* _enemyWEAK = RuntimeManager.CreateInstance(FmodEvents.Instance.Enemy1SoundWEAK);
        _enemyWEAK.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));//Set the 3D attributes of the sound to the position of the enemy.
        
        _enemyREMEMBER = RuntimeManager.CreateInstance(FmodEvents.Instance.Enemy1SoundREMEMBER);
        _enemyREMEMBER.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        
        _enemyALONE = RuntimeManager.CreateInstance(FmodEvents.Instance.EnemySoundALONE);
        _enemyALONE.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        */
        _enemymulti = RuntimeManager.CreateInstance(FmodEvents.Instance.EnemiesSoundMulti);
        _enemymulti.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        
    }
    
    // Start is called before the first frame update
    public void EnemyWeak()
    {
        _enemymulti.start();
        
    }
    
    /*public void EnemyRemember()
    {
        
            _enemyREMEMBER.start();
    }
    
    
    public void EnemyAlone()
    {
        
            _enemyALONE.start();
    }
*/
    
}

