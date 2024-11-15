using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;

public class ForestSound : MonoBehaviour
{
    private EventInstance _forestEventInstance;
    private EventInstance _musicEventInstance;
    private bool musicIsplaying;
    





    void Start()
    {
        // Initialize and play the ocean sound
       _musicEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.Music);
       musicIsplaying = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& musicIsplaying==false)
        {
            _forestEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.ForestSound);
            _forestEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            _forestEventInstance.start();
            _musicEventInstance.start();
            musicIsplaying = true;

        }
        
    }

    void OnDestroy()
    {
        // Stop and release the event instance when the GameObject is destroyed
        _forestEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _forestEventInstance.release();
    }
}