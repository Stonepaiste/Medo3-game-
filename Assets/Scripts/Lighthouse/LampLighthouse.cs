using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLighthouse : MonoBehaviour
{
    //[SerializeField] float rotationSpeed = 0.5f;

    //[SerializeField] GameObject lampSourceN;
    //[SerializeField] GameObject lampSourceS;
    [SerializeField] private GameObject LampInsideRoom1;
    [SerializeField] private GameObject LampInsideRoom2;
    [SerializeField] private GameObject LampInsideRoom3;
    [SerializeField] private GameObject LampInsideRoom4;
    [SerializeField] private GameObject LampInsideRoom5;
    [SerializeField] private GameObject LampInsideRoom6;
    [SerializeField] private GameObject LampInsideRoom7;
    [SerializeField] private GameObject LampInsideRoom8;
    [SerializeField] private GameObject LampInsideRoom9;
    //   [SerializeField] private GameObject LampInsideRoom5;
    [SerializeField] private GameObject LampGhouse;
    //public Transform lampPointN;
    //public Transform lampPointS;

    private bool LampOn = true;
    void Start()
    {
     //   lampSourceN.SetActive(true);
     //   lampSourceS.SetActive(true);
    }

    void Update()
    {
       // transform.Rotate(0, rotationSpeed, 0);
    }

    //TurnPowerOff is called in PowerOff.cs
    public void TurnPowerOff()
    {
        //lampSourceN.SetActive(false);
        //lampSourceS.SetActive(false);
        LampInsideRoom1.SetActive(false);
        LampInsideRoom2.SetActive(false);
        LampInsideRoom3.SetActive(false);
        LampInsideRoom4.SetActive(false);
        LampInsideRoom5.SetActive(false);
        LampInsideRoom6.SetActive(false);
        LampInsideRoom7.SetActive(false);
        LampInsideRoom8.SetActive(false);
        LampInsideRoom9.SetActive(false);
        //LampInsideRoom5.SetActive(false);
        LampGhouse.SetActive(false);
        LampOn = false;
    }

}
