using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[DefaultExecutionOrder(0)]
public class EnemyHandler : MonoBehaviour
{
    EnemyHealth enemyHealth; 
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject[] memory;
    [SerializeField] Vector3[] positions;
    [SerializeField] Vector3 enemyLastPosition;
    List<GameObject> Enemies;
    int numberOfEnemiesDead = 0;
    float timeToDie = 2f;

    private void Awake()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    private void Update()
    {
        EnemyDead();
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

    public int GetNumberOfEnemiesDead() { return numberOfEnemiesDead; }
}
