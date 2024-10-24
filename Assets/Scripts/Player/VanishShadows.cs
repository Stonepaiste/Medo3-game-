using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishShadows : MonoBehaviour
{
    public Transform LightPoint;

  
    void Update()
    {
        Shooting();
    }

    public void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(LightPoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(LightPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
