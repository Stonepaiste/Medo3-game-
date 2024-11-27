using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UIElements;

[DefaultExecutionOrder(0)]
public class EnemyHandler : MonoBehaviour
{
    EnemyHealth enemyHealth; 
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject[] EnemySpawnPositionsGHouse;
    Vector3 position;
    [SerializeField] GameObject[] EnemySpawnPositionsEHouse;
    [SerializeField] GameObject[] memory;
    [SerializeField] Vector3[] positions;
    [SerializeField] Vector3 enemyLastPosition;
    List<GameObject> Enemies;
    int numberOfEnemiesDead = 0;
    float timeToDie = 2f;
  
  

    private void Awake()
    {
        Enemies = new List<GameObject>();
     
    }

    private void Update()
    {
        
    }

    public void EnemyDead()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].GetComponent<EnemyHealth>().shadowHealth <= 0)
            {
                numberOfEnemiesDead++;
                enemyLastPosition = Enemies[i].transform.position;
                Destroy(Enemies[i], timeToDie);
                Enemies.Remove(Enemies[i]);
                SpawnMemories();
                /*if (Enemies[i] == null)
                {
                    Enemies.Remove(Enemies[i])
                }*/
            }
        }
    }

    public void SpawnMemories()
    {
        switch (numberOfEnemiesDead)
        {
            case 2:
                positions[0] = enemyLastPosition;
                Instantiate(memory[0], positions[0], Quaternion.identity, this.transform);
                return;
            case 4:
                positions[1] = enemyLastPosition;
                Instantiate(memory[1], positions[1], Quaternion.identity, this.transform);
                return;
            default:
                return;
        }
    }
    
    
    
    
    public void SpawnEnemiesAtGHouse()
    {
        for (int i = 0;i < EnemySpawnPositionsGHouse.Length ;i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab, EnemySpawnPositionsGHouse[i].transform.position, Quaternion.identity,
                EnemySpawnPositionsGHouse[i].transform);
            Enemies.Add(enemy);
            //enemySpeak.EnemyWeak();
        }
        Debug.Log(Enemies.Count);
   }
    

    public void SpawnEnemiesAtEHouse()
    {
        for (int i = 0; i < EnemySpawnPositionsGHouse.Length; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab, EnemySpawnPositionsEHouse[i].transform.position, Quaternion.identity,
                EnemySpawnPositionsEHouse[i].transform);
            Enemies.Add(enemy);
        }
        Debug.Log(Enemies.Count);
    }

    public int GetNumberOfEnemiesDead() { return numberOfEnemiesDead; }
}
