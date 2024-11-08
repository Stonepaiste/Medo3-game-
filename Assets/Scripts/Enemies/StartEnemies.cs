using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemies : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private float moveSpeed = 5f;
    private Transform player;
    private Renderer enemyRenderer;
    private Collider enemyCollider;


    void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemyCollider = GetComponent<BoxCollider>();
        enemyCollider.enabled = false;
        enemyRenderer = GetComponent<Renderer>();
        enemyRenderer.enabled = false;  // Initially invisible       
    }

    public void ActivateEnemy()
    {
        isActive = true;
        enemyCollider.enabled = true;
        enemyRenderer.enabled = true;  // Ensure visibility if activated externally
    }
    public void MoveTowardsPlayer()
    {
        Vector3 playerPosition = player.position;
        transform.LookAt(playerPosition);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

   

}
