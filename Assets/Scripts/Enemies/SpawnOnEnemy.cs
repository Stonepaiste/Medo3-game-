using UnityEngine;

public class SpawnOnEnemy : MonoBehaviour
{
    public GameObject spawnObject; // The object to spawn
    private bool hasSpawned = false; // To ensure the object is spawned only once per enemy

    // Call this function when the enemy is defeated
    public void DefeatEnemy()
    {
        if (!hasSpawned)
        {
            SpawnObject();
            hasSpawned = true; // Prevent multiple spawns
        }
    }

    private void SpawnObject()
    {
        // Instantiate the object at the enemy's position and rotation
        Instantiate(spawnObject, transform.position, transform.rotation);
        
    }
}
