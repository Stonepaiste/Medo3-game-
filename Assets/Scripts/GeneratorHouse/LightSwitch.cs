using UnityEngine;
using TMPro;
using System.Collections;
using FMODUnity;
using FMOD.Studio;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] float handleDownRotation = -45f;
    [SerializeField] float rotationSpeed = 5f;
    //public TMP_Text pressEText;
    private bool playerIsClose = false;
    private bool handleIsDown = false;
    public bool IsHandleDown => handleIsDown;
    [SerializeField] FMOD.Studio.EventInstance _lightSwitchEventInstance;
    
    private float handleUpRotation = 0f;

    void Start()
    {
        handleUpRotation = handle.localEulerAngles.x;
        _lightSwitchEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.LightSwitch);
    }

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(HandleDownCoroutine());
            _lightSwitchEventInstance.start();
        }

        Quaternion targetRotation;

        if (handleIsDown==true) // Rotating the handle down.
        {
            targetRotation = Quaternion.Euler(handleDownRotation, handle.localEulerAngles.y, handle.localEulerAngles.z);
        }
        else // Rotaing the handle up.
        {
            targetRotation = Quaternion.Euler(handleUpRotation, handle.localEulerAngles.y, handle.localEulerAngles.z);
        }

        handle.localRotation = Quaternion.Lerp(handle.localRotation, targetRotation, Time.deltaTime * rotationSpeed); // Rotate the handle
    }

    private IEnumerator HandleDownCoroutine()
    {
        handleIsDown = true;
        yield return new WaitForSeconds(3.0f);
        handleIsDown = false;
    }

  /*  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            if (pressEText != null)
            {
                pressEText.enabled = true;
                Debug.Log("Press E text enabled");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            handleIsDown = false;
            if (pressEText != null)
            {
                pressEText.enabled = false;
                Debug.Log("Press E text disabled");
            }
        }
    }*/
}