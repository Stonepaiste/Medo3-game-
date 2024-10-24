using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    
    public bool bookofknowledge = false;
    float rotationSpeed = 50;
    public Cinemachine.CinemachineVirtualCamera virtualCameraBook;
    public bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        // Ensure the virtual camera is initially disabled
                if (virtualCameraBook != null)
                {
                    virtualCameraBook.enabled = false;
                }
                
    }

    // Update is called once per frame
    void Update()
    {
        if(bookofknowledge)
        {
            startRotation();
        }
                 
       
    }
    
    void OnTriggerEnter(Collider other)
            {
                if(other.gameObject.tag == "Player")
                {
                    bookofknowledge = true;
                    startRotation();
                    TurnOnVirtualCamera();
                }
            }
            
     void OnTriggerExit(Collider other)
            {
                if(other.gameObject.tag == "Player")
                {
                    bookofknowledge = false;
                    TurnOffVirtualCamera();
                   
                    
                }
            }
            
     public void TurnOnVirtualCamera()
         {
             if (virtualCameraBook != null)
             {
                 virtualCameraBook.enabled = true;
             }
         }
         
     public void TurnOffVirtualCamera()
         {
             if (virtualCameraBook != null)
             {
                 virtualCameraBook.enabled = false;
             }
         }
         
     public void startRotation()
         {
             transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
         }
}
