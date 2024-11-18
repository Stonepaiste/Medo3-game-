using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClickLightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject lightSwitch;
    private bool lightInRoomOn = false;

    [SerializeField] private Text pressE;

    [SerializeField] private UnityEvent ClickSwitch;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressE.enabled = true;
        }
    }
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
