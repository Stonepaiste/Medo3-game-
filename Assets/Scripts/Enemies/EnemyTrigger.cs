using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyTrigger")
        {
            enemyMovement.ActivateEnemy();
        }
    }
}
