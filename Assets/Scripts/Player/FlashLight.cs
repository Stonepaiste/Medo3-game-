using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject lightSource;
    private bool FlashlightOn = false;
    public Transform LightPoint;

    void Start()
    {
        //Turning on the flashlight at start
        lightSource.SetActive(false);

    }

    void Update()
    {
        //if statement to turn on and off the flashlight, when f-key is pressed
        if (Input.GetKeyDown(KeyCode.F))
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

        //calling shooting method for burning shadowmonsters, when flashlight is on
        if (FlashlightOn == true)
        {
            Shooting();
        }
    }

    //Shooting method for burning shadowmonsters with raycast
    public void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(LightPoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(LightPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            //Burning shadowmonsters if raycast hits object with tag "Enemy"
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<ShadowHealth>().TakeDamage();
                //Instantiate(``Unity Asset´´, hit.point, Quaternion.identity);
                //AudioLibrary.PlaySound("Burn");
            }
        }
    }


}
