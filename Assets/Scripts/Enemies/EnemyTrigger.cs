using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GHouseEnemyMovement gHouseEnemyMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyTrigger")
        {
            Debug.Log("Has been entered");
            gHouseEnemyMovement.ActivateEnemy();
            Destroy(other.gameObject);
        }
    }
}
