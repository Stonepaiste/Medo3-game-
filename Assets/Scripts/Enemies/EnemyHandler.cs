using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[DefaultExecutionOrder(0)]
public class EnemyHandler : MonoBehaviour
{
    private static EnemyHandler _instance;
    public static EnemyHandler Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    [SerializeField] GameObject EnemyPrefab = new GameObject();
    [SerializeField] Transform Target;
    [SerializeField] float RadiusAroundTarget = 0.5f;
    public List<EnemyAI> Units = new List<EnemyAI>();

    [SerializeField] Vector3[] positions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 200, 50), "SpawnEnemies"))
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, this.transform);
    }

    private void MakeAgentsCircleTarget()
    {
        for (int i = 0; i < Units.Count; i++)
        {
            Units[i].MoveTowardsTarget(new Vector3(
                Target.position.x + RadiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / Units.Count),
                Target.position.y,
                Target.position.z + RadiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / Units.Count)));
        }
    }
}
