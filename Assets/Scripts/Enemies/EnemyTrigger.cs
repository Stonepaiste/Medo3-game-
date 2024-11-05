using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyMovement enemyMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyTrigger")
        {
            Debug.Log("Has been entered");
            enemyMovement.ActivateEnemy();
            Destroy(other.gameObject);
        }
    }
}
