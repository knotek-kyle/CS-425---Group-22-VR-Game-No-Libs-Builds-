using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    // Patroling behavior
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking behavior
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    //public float Clip;
    //private float Shot = 1; 

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange = false;


    private void Awake()
    {
        player = GameObject.Find("Player10.23").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange);
        playerInAttackRange = Physics.CheckSphere(transform.position, sightRange);

        if (!playerInAttackRange && !playerInSightRange) Patroling();
        if (!playerInAttackRange && playerInSightRange) ChasingPlayer();
        if (playerInAttackRange && playerInSightRange) AttackingPlayer();
    
    }


    private void SearchWalkPoint() 
    {
        float randomZ = Random.RandomRange(-walkPointRange, walkPointRange);
        float randomX = Random.RandomRange(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ );

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint; 

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;


    }


    private void ChasingPlayer()
    {
        agent.SetDestination(player.position);
    }


    private void AttackingPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 8f, ForceMode.Impulse);

                //Shot++;
                //Debug.Log(Shot);

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy() 
    {
        Destroy(gameObject);
    }

}
