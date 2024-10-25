using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{

    public bool bookofknowledge = false;
    float rotationSpeed = 50;
    public Cinemachine.CinemachineVirtualCamera virtualCameraBook;
   // public GameObject Canvas;
    public GameObject pushF;
    public GameObject pushEsc;
 
    
    
    //public GameObject CanvasOff;
    public bool isRotating = false;
    

    // Start is called before the first frame update
    void Start()
    {

        bookofknowledge = false;
        pushF.gameObject.SetActive(false);
        pushEsc.gameObject.SetActive(false);
        // Ensure the virtual camera is initially disabled
        if (virtualCameraBook != null)
        {
            virtualCameraBook.enabled = false;
        }
        

    }

    // Update is called once per frame

    void Update()
    {
        BookCanvasEnabled();
        BookCanvasDisabled();
        if(isRotating)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pushF.gameObject.SetActive(true);
            bookofknowledge = true;
           // Canvas.gameObject.SetActive(true);
         

        }

    }

    private void BookCanvasEnabled()
    {
        if (bookofknowledge == true && Input.GetKeyDown(KeyCode.F))
        {
            isRotating=true;
            TurnOnVirtualCamera();
            //Canvas.gameObject.SetActive(false);
            pushF.gameObject.SetActive(false);
            pushEsc.gameObject.SetActive(true);
          
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bookofknowledge = false;
            //Canvas.gameObject.SetActive(false);


        }
    }

    private void BookCanvasDisabled()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isRotating = false;
            TurnOffVirtualCamera();
            pushEsc.gameObject.SetActive(false);
           

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

    



}
            
