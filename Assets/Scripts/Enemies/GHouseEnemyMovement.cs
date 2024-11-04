using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHouseEnemyMovement : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private float moveSpeed = 5f;
    private Transform player;
    private Renderer enemyRenderer;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.enabled = false;  // Initially invisible
    }

    void Update()
    {
        if (isActive)
        {
            MoveTowardsPlayer();
        }
    }

    public void ActivateEnemy()
    {
        isActive = true;
        enemyRenderer.enabled = true;  // Make the enemy visible when activated
    }

    private void MoveTowardsPlayer()
    {
        Vector3 playerPosition = player.position;
        transform.LookAt(playerPosition);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}