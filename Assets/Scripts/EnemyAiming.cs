//Vaishanvi Desai
//EnemyAI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyAiming : MonoBehaviour
{
    public Rig aimLayer;
    public float aimDuration = 10f;
    public float maxDistance = 2f;
    public Transform playerTransform;
    Animator animator;
    UnityEngine.AI.NavMeshAgent agent;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float sqdistance = (playerTransform.position - agent.destination).sqrMagnitude;
        if(sqdistance > maxDistance*maxDistance){
                aimLayer.weight += Time.deltaTime / aimDuration;
        }
        else{
            aimLayer.weight -= Time.deltaTime / aimDuration;
        }
    }
}
