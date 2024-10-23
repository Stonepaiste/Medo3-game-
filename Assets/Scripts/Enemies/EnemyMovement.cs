using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool isActive = false;
    [SerializeField] float moveSpeed = 5f; // Adjusted to a lower value
    Transform player;
    Transform enemy;

    void Awake()
    {
        player = FindObjectOfType<PlayerInput>().transform;  // Assuming PlayerInput is attached to the player
        enemy = this.transform;
    }

    void Update()
    {
        if (isActive)
        {
            MoveTowardsPlayer();
        }
    }

    public void MoveTowardsPlayer()
    {
        Vector3 playerPosition = player.position;
        enemy.LookAt(playerPosition);  // Enemy looks at the player
        enemy.position += transform.forward * moveSpeed * Time.deltaTime;  // Move forward toward the player
    }

    public void ActivateEnemy()
    {
        isActive = true;
    }
}

