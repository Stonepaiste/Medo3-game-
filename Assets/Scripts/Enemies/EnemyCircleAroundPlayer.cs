using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCircleAroundPlayer : MonoBehaviour
{
    List<GameObject> enemyCircle = new List<GameObject>();
    [SerializeField] GameObject enemyPrefab;
    EnemyAI enemyAI;
    [SerializeField] int numberOfEnemies = 6;
    public Transform Target;
    public float RadiusAroundTarget = 0.5f;

    private void Awake()
    {
        Target = FindObjectOfType<PlayerInputHandler>().transform;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            enemyCircle.Add(enemyPrefab);
        }
    }

    /*private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 200, 50), "Move To Target"))
        {
            MakeAgentsCircleTarget();
        }
    }*/

    public void MakeAgentsCircleTarget()
    {
        for (int i = 0; i < enemyCircle.Count; i++)
        {
            Vector3 position = new Vector3(Target.position.x + RadiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / enemyCircle.Count), Target.position.y, Target.position.z + RadiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / enemyCircle.Count)
    );
            Instantiate(enemyCircle[i], position, Quaternion.identity, this.transform);


        }
    }
}
