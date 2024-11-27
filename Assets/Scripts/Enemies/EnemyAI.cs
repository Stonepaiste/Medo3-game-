using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject model;
    [SerializeField] float radiusAroundTarget = 0.5f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    private EnemySpeak enemyspeak; //Reference to the FmodEvents script.
    
    

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Awake()
    {
        enemyspeak = GetComponent<EnemySpeak>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        model.SetActive(false);
        target = FindObjectOfType<PlayerInputHandler>().transform;
        
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            model.SetActive(true);
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            enemyspeak.EnemyWeak();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    public void OnDeath()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        navMeshAgent.enabled = false;
        this.enabled = false;

    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            MoveTowardsTarget(target.position);
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            //What happens when getting to the player? 
        }
    }

    public void MoveTowardsTarget(Vector3 position)
    {
        //GetComponent<Animator>().SetBool("attack", false);
        navMeshAgent.SetDestination(position);
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void MoveTo(Vector3 Position)
    {
        navMeshAgent.SetDestination(Position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
