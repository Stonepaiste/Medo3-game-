using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private bool isActive = false;
    public StartEnemies startEnemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Has been entered");
            startEnemies.ActivateEnemy();
            isActive = true;
            //Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (isActive)
        {
            startEnemies.MoveTowardsPlayer();
        }
    }
}



