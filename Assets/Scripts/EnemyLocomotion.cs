using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotion : MonoBehaviour
{
    public Transform playerTransform;
    Animator animator;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    float timer = 0.0f;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0.0f){
            float sqdistance = (playerTransform.position - agent.destination).sqrMagnitude;
            if(sqdistance > maxDistance*maxDistance){
                agent.destination = playerTransform.position;
            }
            timer = maxTime;
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);

    }
}
