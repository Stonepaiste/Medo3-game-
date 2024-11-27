using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{

    EnemyHandler enemyHandler;

    private void Awake()
    {
        enemyHandler = FindObjectOfType<EnemyHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyHandler.SpawnEnemiesAtGHouse();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);
    }
}
