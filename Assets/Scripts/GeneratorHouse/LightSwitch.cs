using UnityEngine;
using TMPro;

public class LightSwitch : MonoBehaviour
{
    public Transform handle;
    public float handleDownRotation = -45f;
    public float rotationSpeed = 5f;
    public TMP_Text pressEText;
    private bool playerIsClose = false;
    private bool handleIsDown = false;
    public bool IsHandleDown => handleIsDown;

    private float handleUpRotation = 0f;

    void Start()
    {
        //if (pressEText != null)
        //{
          //  pressEText.enabled = false;
        //}

        handleUpRotation = handle.localEulerAngles.x;
    }

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E) && !handleIsDown)
        {
            handleIsDown = true;
        }

        Quaternion targetRotation;

        if (handleIsDown)
        {
            targetRotation = Quaternion.Euler(handleDownRotation, handle.localEulerAngles.y, handle.localEulerAngles.z);
        }
        else
        {
            targetRotation = Quaternion.Euler(handleUpRotation, handle.localEulerAngles.y, handle.localEulerAngles.z);
        }

        handle.localRotation = Quaternion.Lerp(handle.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
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
    }
}
