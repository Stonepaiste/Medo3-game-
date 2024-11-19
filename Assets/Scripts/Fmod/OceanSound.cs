using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class OceanSoundPlayer : MonoBehaviour
{
    private EventInstance _oceanEventInstance;
    private EventInstance _rainThunderEventInstance;

    void Start()
    {
        // Initialize and play the ocean sound
        _oceanEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.Ocean);
        _oceanEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        
        // Initialize and play the forest and rain sound
        _rainThunderEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.RainThunder);
        _rainThunderEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        
        _oceanEventInstance.start();
        _rainThunderEventInstance.start();
    }

    void OnDestroy()
    {
        // Stop and release the event instance when the GameObject is destroyed
        _oceanEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _oceanEventInstance.release();
        
        _rainThunderEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _rainThunderEventInstance.release();
    }
}