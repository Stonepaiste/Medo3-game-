using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerTrigger")
        {
           GetComponent<LampLighthouse>().TurnPowerOff(); //Calling method from LampLighthouse.cs
           Debug.Log("Power off");
        }
    }
    void Update()
    {
        
    }
}
