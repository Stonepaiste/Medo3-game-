using UnityEngine;

public class SpawnOnEnemy : MonoBehaviour
{
    public GameObject spawnObject; // The object to spawn
    public Vector3 spawnOffset = new Vector3(0, 1, 0); // Offset to ensure the object spawns above the ground
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
        Debug.Log("Glasses spawned");
        // Capture the enemy's position and rotation before destroying it
        Vector3 spawnPosition = transform.position + spawnOffset;
        Quaternion spawnRotation = transform.rotation;

        // Log the position and rotation for debugging
        Debug.Log($"Spawning object at position: {spawnPosition}, rotation: {spawnRotation}");

        // Instantiate the object at the captured position and rotation
        Instantiate(spawnObject, spawnPosition, spawnRotation);
    }
}