using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int shadowHealth = 100;
    private SpawnOnEnemy spawnOnEnemy; // Reference to SpawnOnEnemy script
    Material shadowMaterial;
    [SerializeField] GameObject Enemy;

    private void Start()
    {
        // Get the SpawnOnEnemy component attached to the same GameObject
        spawnOnEnemy = GetComponent<SpawnOnEnemy>();
        shadowMaterial = Enemy.GetComponent<SkinnedMeshRenderer>().materials[1];
    }

    public void TakeDamage()
    {
        shadowHealth -= 1;
        shadowMaterial.SetFloat("_CutOff_Height", shadowHealth / 10);
    }

    private void Update()
    {
        if (shadowHealth <= 0)
        {
           // Spawn the object right before destroying the enemy
            if (spawnOnEnemy != null)
            {
                spawnOnEnemy.DefeatEnemy();
                gameObject.SetActive (false);
            }

          
        }

      
    }
}

