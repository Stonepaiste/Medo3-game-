using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLighthouse : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.5f;

    [SerializeField] GameObject lampSourceN;
    [SerializeField] GameObject lampSourceS;    
    public Transform lampPointN;
    public Transform lampPointS;

    private bool LampOn = true;
    void Start()
    {
        lampSourceN.SetActive(true);
        lampSourceS.SetActive(true);
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    //TurnPowerOff is called in PowerOff.cs
    public void TurnPowerOff()
    {
        lampSourceN.SetActive(false);
        lampSourceS.SetActive(false);
        LampOn = false;
    }

}
