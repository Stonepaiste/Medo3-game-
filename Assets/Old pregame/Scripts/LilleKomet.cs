using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LilleKomet : MonoBehaviour
{
    public float Mass = 100f;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down* Mass, ForceMode.Force);
    }
}
