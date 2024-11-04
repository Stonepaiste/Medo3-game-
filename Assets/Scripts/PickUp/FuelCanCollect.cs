using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelCanCollect : MonoBehaviour
{

    public bool fuelCan = false;
   
    
    // public GameObject Canvas;
    public GameObject pushE;
    public GameObject fuelCanObject;  // Reference to the fuel can object in the scene
    public Transform playerCamera;    // Reference to the player's camera


    // Start is called before the first frame update
    void Start()
    {

        fuelCan = false;
        pushE.gameObject.SetActive(false);
       
    }


    // Update is called once per frame

    void Update()
    {
        BookCanvasEnabled();

        HandleFuelCanCollection();
        
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pushE.gameObject.SetActive(true);
            fuelCan = true;
            // Canvas.gameObject.SetActive(true);


        }

    }

    private void HandleFuelCanCollection()
    {
        if (fuelCan == false && pushE.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            fuelCan = true;
            pushE.gameObject.SetActive(false);  // Hide prompt

            // Make the fuel can a child of the camera so it moves with the player
            fuelCanObject.transform.SetParent(playerCamera);
            fuelCanObject.transform.localPosition = new Vector3(0.5f, -0.5f, 1f);  // Adjust the position to appear in front of the player
        }
    }


    private void BookCanvasEnabled()
    {
        if (fuelCan == true && Input.GetKeyDown(KeyCode.E))
        {
           
           
            pushE.gameObject.SetActive(false);
          

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fuelCan= false;
            pushE.gameObject.SetActive(false);


        }
    }

   
        
   


 

}