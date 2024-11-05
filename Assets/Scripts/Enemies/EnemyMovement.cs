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
        player = GameObject.Find("Player 2").transform;
        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.enabled = false;  // Initially invisible


        /*padlock = GetComponent<Padlock>();

        if (padlock == null)
        {
            Debug.LogError("Padlock component is not found on the same GameObject.");
        }
        */
    }

    void Update()
    {
        if (padlock == null)
        {
            Debug.LogError("Padlock reference is not assigned in the Inspector.");
        }

        // Check if the padlock has activated the enemy only once
        if (padlock != null && padlock.enemycanspawn && !isActive)
        {
            Debug.Log("Activating enemy");
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
