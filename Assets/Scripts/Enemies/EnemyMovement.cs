using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool isActive;
    [SerializeField] float moveSpeed = 50f;
    Transform player;
    Transform enemy;

    void Awake()
    {
        player = FindObjectOfType<PlayerInput>().transform;
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
        enemy.LookAt(playerPosition);
        enemy.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void ActivateEnemy()
    {
        isActive = true;
    }
}
