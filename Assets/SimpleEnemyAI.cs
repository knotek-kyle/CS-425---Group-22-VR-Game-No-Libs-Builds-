using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public Transform Itemspawnpoint;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    // Enemy attributes
    public bool IsStatic;       // used to stop the enemy AI in general
    public Vector3 playerposition;

    // Patroling behavior
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking behavior
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;


    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Player10.31").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange && !playerInSightRange && !IsStatic) Patrolling();
        if (!playerInAttackRange && playerInSightRange && !IsStatic) ChasingPlayer();
        if (playerInAttackRange && playerInSightRange) AttackingPlayer();
    
    }



    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint; 

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }


    private void ChasingPlayer()
    {
        agent.SetDestination(player.position);
    }


    private void AttackingPlayer()
    {
        agent.SetDestination(transform.position);

        playerposition = new Vector3(player.position.x, 1f, playerposition.z);
        transform.LookAt(playerposition);

        if (!alreadyAttacked)
        {

                Rigidbody rb = Instantiate(projectile, Itemspawnpoint.position, Quaternion.identity).GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 8f, ForceMode.Impulse);

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy() 
    {
        Destroy(gameObject);
    }

}
