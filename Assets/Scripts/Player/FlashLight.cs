using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject fire;
    public float moveFire = 5f;
    public float firePosition = -0.1f;


    [SerializeField] GameObject lightSource;
    [SerializeField] float sphereRadius = 0.1f; // Adjust the radius as needed
    private bool FlashlightOn = false;
    public Transform LightPoint;


    void Start()
    {
        //Turning on the flashlight at start
        lightSource.SetActive(false);

    }

    void Update()
    {
        //if statement to turn on and off the flashlight, when space-key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
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
        else
        {
            fire.SetActive(false);
        }
    }

    //Shooting method for burning shadowmonsters with raycast
    public void Shooting()
    {
        RaycastHit hit;

        if (Physics.SphereCast(LightPoint.position, sphereRadius, transform.TransformDirection(Vector3.forward), out hit, 100))

        {
            //Debug.DrawLine(LightPoint.position, hit.point, Color.yellow);  //Debug line for raycast

            //Burning shadowmonsters if raycast hits object with tag "Enemy"
            if (hit.transform.tag == "Enemy") 
            {
                hit.transform.GetComponent<ShadowHealth>().TakeDamage(); //calling TakeDamage method from ShadowHealth script

                //Fire effect
                fire.SetActive(true);
                fire.transform.position = Vector3.Lerp(fire.transform.position, hit.point+new Vector3(0,0,firePosition), moveFire*Time.deltaTime);
                //AudioLibrary.PlaySound("Burn");
            }
            else //if raycast hits other objects, fire effect is off
            {
                fire.SetActive(false);
            }
        }
        else //if raycast doesn't hit anything, fire effect is off
        {
            fire.SetActive(false);
        }
    }


}
