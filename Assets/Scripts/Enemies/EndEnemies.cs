using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEnemies : MonoBehaviour
{
    private bool isActive = false;
    private bool isSwitchPulled = false;

    [SerializeField] private float moveSpeed = 5f;
    private Transform player;
    private Renderer enemyRenderer;

    [SerializeField] private LightSwitch lightSwitch;
    [SerializeField] private PickUpAndDrop pickUpAndDrop;

    [SerializeField] private GameObject lonelyCanvas;

    void Awake()
    {
        player = GameObject.Find("Player 2").transform;
        enemyRenderer = GetComponent<SkinnedMeshRenderer>();
        enemyRenderer.enabled = false;
        lonelyCanvas.SetActive(false);
    }

    private void Update()
    {
        if (lightSwitch != null && lightSwitch.IsHandleDown)
        {
            isSwitchPulled = true;
        }

        if (isSwitchPulled && pickUpAndDrop != null && pickUpAndDrop.FuelCanDropped && !isActive)
        {
            ActivateEnemy();
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
        enemyRenderer.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            lonelyCanvas.SetActive(true);
            Destroy(gameObject);
        }
    }
}
