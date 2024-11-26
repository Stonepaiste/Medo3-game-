using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class EngineFailSound : MonoBehaviour
{
    EventInstance _engineFailEventInstance;
    private bool _isPlayerInTrigger = false;
    EventInstance _moreFuelEventInstance;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInTrigger = false;
        }
    }

    void Update()
    {
        if (_isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            EngineFailSoundPlay();
            
            Invoke("MoreFuelSoundPlay", 5f);
            Invoke("OnDestroy", 10f);
        }
    }

    void EngineFailSoundPlay()
    {
        _engineFailEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.Enginefail);
        _engineFailEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        _engineFailEventInstance.start();
        
    }

    void OnDestroy()
    {
        _engineFailEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _engineFailEventInstance.release();
        _moreFuelEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _moreFuelEventInstance.release();
    }
    
    void MoreFuelSoundPlay()
    {
        _moreFuelEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.INeedFuel);
        _moreFuelEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        _moreFuelEventInstance.start();
    }
}
