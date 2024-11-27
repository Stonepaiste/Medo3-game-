using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class RadioEHouse : MonoBehaviour
{
    EventInstance _eHouseradioEventInstance;
    [SerializeField] GameObject _textAlexAreYouOkay; // Assign this in the Inspector

    void Start()
    {
        if (_textAlexAreYouOkay != null)
        {
            _textAlexAreYouOkay.SetActive(false);
        }
        else
        {
            Debug.LogError("TextAlexAreYouOkay GameObject is not assigned.");
        }
    }

    public void PlayAndDestroyEhouseRadio()
    {
        Invoke("PlayEhouseRadio",2f);
        Invoke ("StarttextAlexAreYouOkay", 2f);
        Invoke("DestroyTextAlexAreYouOkay",8f);
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
    
    public void DestroyTextAlexAreYouOkay()
    {
        if (_textAlexAreYouOkay != null)
        {
            _textAlexAreYouOkay.SetActive(false);
        }
    }
    
    public void StarttextAlexAreYouOkay()
    {
        if (_textAlexAreYouOkay != null)
        {
            _textAlexAreYouOkay.SetActive(true);
        }
    }

    void Update()
    {
    }
}
