using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int shadowHealth = 100;
    private SpawnOnEnemy spawnOnEnemy; // Reference to SpawnOnEnemy script
    [SerializeField] GameObject Enemy;

    private void Start()
    {   
        // Get the SpawnOnEnemy component attached to the same GameObject
        spawnOnEnemy = GetComponent<SpawnOnEnemy>();
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage runs!");
        shadowHealth -= 1;
    }

    private void Update()
    {
        if (shadowHealth <= 0)
        {
            shadowHealth = 0;
           // Spawn the object right before destroying the enemy
            if (spawnOnEnemy != null)
            {
                spawnOnEnemy.DefeatEnemy();
                gameObject.SetActive (false);
            }

          
        }

      
    }
}

