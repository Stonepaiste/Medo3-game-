using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collission works");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("this works");
        }
    }
}
