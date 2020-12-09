// using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    // [SerializeField]
    private NavMeshAgent agent;
    // [SerliazeField]
    private VirtualMuseum.Player player;
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    [Header("Attacking")]
    public float timeBetweenAttacks;
    bool alreadyAttacked;


    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Awake()
    {
        player = (VirtualMuseum.Player)UnityEngine.Object.FindObjectOfType<VirtualMuseum.Player>();
        agent = GetComponent<NavMeshAgent>();
    }

   private void Update() {
    {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if(!playerInSightRange && !playerInAttackRange) Patroling();
            if(playerInSightRange && !playerInAttackRange) ChasePlayer();
            if(playerInAttackRange && playerInSightRange) AttackPlayer();
        }
  }

  private void Patroling()
  {
    if(!walkPointSet) SearchWalkPoint();

    if(walkPointSet)
            agent.SetDestination(walkPoint);

      Vector3 distanceToWalkPoint = transform.position - walkPoint;

      if(distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.transform);

        // TODO: Attack Code

        if(!alreadyAttacked) {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
