using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;


    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;

    Transform target;

    void Start()
    {
        health = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }


        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }


        else if (distanceToTarget <= chaseRange)
        {
        isProvoked = true;
            ChaseTarget();

        }

    }


    public void OnDamageTaken()
    {
        isProvoked= true;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotaion = Quaternion.LookRotation(new Vector3 (direction.x , 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotaion, Time.deltaTime * turnSpeed);
    }

    private void EngageTarget()
    {

        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {

        ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
         AttackTarget();
        }
    }


    private void ChaseTarget()
    {
        if (health.IsDead()) return;

            GetComponent<Animator>().SetBool("isAttacking", false);

        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
    }

}
