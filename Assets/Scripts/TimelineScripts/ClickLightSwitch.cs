using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickLightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject lightSwitch;
    private bool lightInRoomOn = false;

    [SerializeField] private UnityEvent ClickSwitch;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !lightInRoomOn)
        {
            lightSwitch.SetActive(true);
            lightInRoomOn = true;

            ClickSwitch.Invoke();

            Debug.Log("Switch is clicked");
        }
    }

}
