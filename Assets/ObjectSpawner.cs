using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject spawnObject1;
    public GameObject spawnObject2;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    private bool enemy1Killed = false;
    private bool enemy2Killed = false;

    void Update()
    {
        // Check if each enemy is inactive
        if (enemy1 == null && !enemy1Killed)
        {
            enemy1Killed = true;
        }

        if (enemy2 == null && !enemy2Killed)
        {
            enemy2Killed = true;
        }

        // If both enemies are killed, spawn objects
        if (enemy1Killed && enemy2Killed)
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        // Instantiate the objects at the specified spawn points
        Instantiate(spawnObject1, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(spawnObject2, spawnPoint2.position, spawnPoint2.rotation);

        // Destroy this script to prevent further spawning
        Destroy(this);
    }
}
