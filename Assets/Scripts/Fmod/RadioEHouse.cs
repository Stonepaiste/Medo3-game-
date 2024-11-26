using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class RadioEHouse : MonoBehaviour
{
    
    EventInstance _eHouseradioEventInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void PlayAndDestroyEhouseRadio()
    {
        PlayEhouseRadio();
        Invoke("OnDestroy", 10f);
    }
    
    
    public void PlayEhouseRadio()
    {
        _eHouseradioEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.AlexAreYouOkay);
        _eHouseradioEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        _eHouseradioEventInstance.start();
    }

    public void OnDestroy()
    {
        _eHouseradioEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _eHouseradioEventInstance.release();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
