using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
public class ThunderSound : MonoBehaviour
{
    private EventInstance _ThunderStromSoundEvent;
    public EventReference thunderSound;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _ThunderStromSoundEvent = RuntimeManager.CreateInstance(FmodEvents.Instance.Thunder);
        _ThunderStromSoundEvent.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
    }

    // Update is called once per frame
    
    public void PlayThunderSound()
    {
        _ThunderStromSoundEvent.start();
    }
    
    
    void OnDestroy()
    {
        // Stop and release the event instance when the GameObject is destroyed
        _ThunderStromSoundEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _ThunderStromSoundEvent.release();
        
    }
    
}
