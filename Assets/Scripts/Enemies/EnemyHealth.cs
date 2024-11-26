using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int shadowHealth = 100;
    private SpawnOnEnemy spawnOnEnemy; // Reference to SpawnOnEnemy script
    [SerializeField] GameObject Enemy;
    [SerializeField] Material shadowMaterial;
    float cutOffHeight;
    [SerializeField] float decreaseCutOffHeight = 0.1f;

    private void Start()
    {
        cutOffHeight = 10;
        // Get the SpawnOnEnemy component attached to the same GameObject
        spawnOnEnemy = GetComponent<SpawnOnEnemy>();
        shadowMaterial.SetFloat("_CutOff_Height", cutOffHeight);
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage runs!");
        shadowHealth -= 1;
        cutOffHeight -= decreaseCutOffHeight;
        shadowMaterial.SetFloat("_CutOff_Height", cutOffHeight);
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

