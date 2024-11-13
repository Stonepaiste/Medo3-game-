using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;

public class ForestSound : MonoBehaviour
{
    private EventInstance _forestEventInstance;






    void Start()
    {
        // Initialize and play the ocean sound
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _forestEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.ForestSound);
            _forestEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            _forestEventInstance.start();
        }
        
    }

    void OnDestroy()
    {
        // Stop and release the event instance when the GameObject is destroyed
        _forestEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _forestEventInstance.release();
    }
}