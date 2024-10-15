using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class OceanSoundPlayer : MonoBehaviour
{
    private EventInstance _oceanEventInstance;



    void Start()
    {
        // Initialize and play the ocean sound
        _oceanEventInstance = RuntimeManager.CreateInstance(FmodEvents.instance.Ocean);
        _oceanEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        _oceanEventInstance.start();
    }

    void OnDestroy()
    {
        // Stop and release the event instance when the GameObject is destroyed
        _oceanEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _oceanEventInstance.release();
    }
}