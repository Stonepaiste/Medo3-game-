using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Flashlight : MonoBehaviour
{
    public GameObject fire;
    public float moveFire = 5f;
    public float firePosition = -0.1f;


    [SerializeField] GameObject lightSource;
    [SerializeField] float sphereRadius = 0.1f; // Adjust the radius as needed
    private bool FlashlightOn = false;
    public Transform LightPoint;
    private EventInstance _flashlightOn;
    private EventInstance _flashlightOff;
    


    void Start()
    {
        //Turning off the flashlight at start
        lightSource.SetActive(false);
        _flashlightOn = RuntimeManager.CreateInstance(FmodEvents.Instance.FlashlightOn);
        _flashlightOff = RuntimeManager.CreateInstance(FmodEvents.Instance.FlashlightOff);

    }

    void Update()
    {
        //if statement to turn on and off the flashlight, when f is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightOn == true)
            {
                lightSource.gameObject.SetActive(true);
                FlashlightOn = false;
                _flashlightOn.start();
                
               
            }
            else
            {
                lightSource.gameObject.SetActive(false);
                FlashlightOn = false;
                _flashlightOff.start();
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
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(); //calling TakeDamage method from ShadowHealth script

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
