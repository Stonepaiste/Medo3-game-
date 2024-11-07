using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometScirpt : MonoBehaviour
{
    
    public float gravity = 9.81f;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }
}
