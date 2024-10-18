using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool isActive;
    [SerializeField] float moveSpeed = 50f; 
    Vector3 playerPosition;
    Vector3 enemyPosition;
    Transform enemy; 

    void Awake()
    {
        isActive = gameObject.activeSelf;
        playerPosition = FindObjectOfType<PlayerInput>().transform.position;
        enemy = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            MoveTowardsPlayer();
        }
    }
    public void MoveTowardsPlayer()
    {
        enemy.LookAt(playerPosition);
        enemy.position += transform.forward * moveSpeed * Time.deltaTime;

    }
}
