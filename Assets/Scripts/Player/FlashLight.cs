using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject lightSource;
    private bool FlashlightOn = false;

   

    void Start()
    {
        lightSource.SetActive(false);
    }


    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightOn == false)
            {
                lightSource.gameObject.SetActive(true);
                FlashlightOn = true;
                
            }
            else
            {
                lightSource.gameObject.SetActive(false);
                FlashlightOn = false;
            }
        }
    }

    
}
