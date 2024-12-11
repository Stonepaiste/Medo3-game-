using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UIElements;

//This script is placed on SpawnManager under Managers in Hierarchy.
[DefaultExecutionOrder(0)]
public class EnemyHandler : MonoBehaviour
{   
    //Reference to EnemyHealth script
    EnemyHealth enemyHealth;

    [Header("The enemy prefab")]
    [SerializeField] GameObject EnemyPrefab;

    [Header("GHouse Enemy Spawn")]
    [Tooltip("An array. Indicate how many enemies should spawn. And add the GHouse enemies from '--ENEMIES--' into the slots.")]
    [SerializeField] GameObject[] EnemySpawnPositionsGHouse;
    Vector3 position;   //Hvor er den brugt?

    [Header("EHouse Enemy Spawn")]
    [Tooltip("An array. Indicate how many enemies should spawn. And add the EHouse enemies from '--ENEMIES--' into the slots.")]
    [SerializeField] GameObject[] EnemySpawnPositionsEHouse;

    [Header("Memories to spawn")]
    [Tooltip("An array. Indicate how many memory objects should spawn. Add the memory prefabs into the slots.")]
    [SerializeField] GameObject[] memory;

    [Header("Memory Spawn Position")]
    [Tooltip("An array. Indicate how many possible positions the memory can spawn. Then type in transform position.")]
    [SerializeField] Vector3[] positions;
    [Header("The enemy's last position")]
    [Tooltip("At which position the last enemy is defeated")]
    [SerializeField] Vector3 enemyLastPosition;
    [Header("Memory offset spawn")]
    [Tooltip("Set a value for memory to spawn a little above ground.")]
    [SerializeField] float memoryYOffset = 2f;

    //To count the enemies that can be defeated
    List<GameObject> Enemies;

    //The number of dead enemies to begin with
    int numberOfEnemiesDead = 0;
    //When the enemy has lost all health how long after they should be destroyed
    float timeToDie = 1f;

    //Reference to the AssignmentTrigger script
    AssignmentTrigger assignmentTrigger;
    //[SerializeField] GameObject assignmentTriggerObject;
   
    //When Awake is called, it finds the suitable 'Assignment object'
    //under '--UI--' to spawn when last enemy is defeated and memory
    //has spawned at the position.
    private void Awake()
    {
        assignmentTrigger = FindObjectOfType<AssignmentTrigger>();
        Enemies = new List<GameObject>();
    }

    //
    public void EnemyDead()
    {
        for (int i = 0; i < Enemies.Count; i++)                     //Loopes through the 'Enemies' list and check 
        {                                                           //(continues in the next comment line)
            if (Enemies[i].GetComponent<EnemyHealth>().shadowHealth <= 0) //if any enemy's 'ShadowHealth' is 0 or below. 
            {
                numberOfEnemiesDead++;                              //Increase the count of dead enemies.
                enemyLastPosition = Enemies[i].transform.position;  //Stores the position of the last defeated enemy.
                Destroy(Enemies[i], timeToDie);                     //After a delay destroys the defeated enemy
                Enemies.Remove(Enemies[i]);                         //and removes the destroyed enemy from the 'Enemies' list.
                SpawnMemories();                                    //Then it triggers the memory.
                /*if (Enemies[i] == null)
                {
                    Enemies.Remove(Enemies[i])
                }*/
            }
        }
    }

    public void SpawnMemories()
    {
        switch (numberOfEnemiesDead)                                //Checks the 'numberOfEnemiesDead', for both 3 dead and 6 dead enemies
        {                                                           //and ensures that memories are only spawned if speficic conditions are met.
            case 3:
                positions[0] = enemyLastPosition;                   //For this case: set the position from 'positions' to the value of 'enemyLastPosition'.
                positions[0].y += memoryYOffset;                    //then make the memory spawn a little above ground by adding 'memoryYOffset'.
                Instantiate(memory[0], positions[0], Quaternion.identity, this.transform); //Spawn memory[0] (see Inspector).
                assignmentTrigger.ShowAssignmentMessage("Pick up the glasses");            //Trigger the suitable 'Assignment object' with the name 'Pick up the glasses'. -- den her skal altså tjekkes. Jeg tror ikke at den hedder det mere. Oplever vi fejl med det? så er det sgu nok derfor.
                return;
            case 6:
                positions[1] = enemyLastPosition;                   //Does the same as case 3, now for 6 dead enemies.
                positions[1].y += memoryYOffset; 
                Instantiate(memory[1], positions[1], Quaternion.identity, this.transform);
                //Here should be but an assignmentTrigger for pick up the book - but have we done something else for this? If so, why?
                return;
            default:
                return;
        }
    }
    
    public void SpawnEnemiesAtGHouse()
    {
        for (int i = 0;i < EnemySpawnPositionsGHouse.Length ;i++)   //Loopes through all the 'EnemySpawnPositionsGHouse'´set in the inspector
        {
            GameObject enemy = Instantiate(EnemyPrefab, EnemySpawnPositionsGHouse[i].transform.position,   //For each 'EnemySpawnPositionsGhosuse' in the inspector, an instance
                               Quaternion.identity, EnemySpawnPositionsGHouse[i].transform);               //of the 'EnemyPrefab' (also set in the inspector) is created. 
            Enemies.Add(enemy);                                                                            //And then each instantiated enemy is added to the 'Enemies' list.
            //enemySpeak.EnemyWeak();
        }
        Debug.Log(Enemies.Count);
   }

    public void SpawnEnemiesAtEHouse()
    {
        for (int i = 0; i < EnemySpawnPositionsEHouse.Length; i++)  //Just as the previuous function, this one does the same, just for the enemies at the EHouse.
        {
            GameObject enemy = Instantiate(EnemyPrefab, EnemySpawnPositionsEHouse[i].transform.position, 
                               Quaternion.identity, EnemySpawnPositionsEHouse[i].transform);
            Enemies.Add(enemy);
        }
        Debug.Log(Enemies.Count);
    }

    public int GetNumberOfEnemiesDead() { return numberOfEnemiesDead; }
}
