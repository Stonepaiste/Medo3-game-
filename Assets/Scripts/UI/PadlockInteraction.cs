using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockInteraction : MonoBehaviour
{
    public GameObject padlockCanvas;

    private void Start()
    {
        padlockCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            padlockCanvas.SetActive(true);
        }
    }
}