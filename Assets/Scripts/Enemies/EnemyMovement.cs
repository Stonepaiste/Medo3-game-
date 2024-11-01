using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private float moveSpeed = 5f;
    private Transform player;
    private Renderer enemyRenderer;
    public Padlock padlock;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.enabled = false;  // Initially invisible
    }

    void Update()
    {
        // Check if the padlock has activated the enemy only once
        if (padlock != null && padlock.enemycanspawn && !isActive)
        {
            isActive = true;
            enemyRenderer.enabled = true;  // Make the enemy visible
        }

        if (isActive)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 playerPosition = player.position;
        transform.LookAt(playerPosition);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void ActivateEnemy()
    {
        isActive = true;
        enemyRenderer.enabled = true;  // Ensure visibility if activated externally
    }
}
