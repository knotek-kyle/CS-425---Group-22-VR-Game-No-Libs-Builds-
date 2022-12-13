using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject playerTarget;
    public float speed;
    public float minimumDistance;

    

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerTarget.transform.position) > minimumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speed * Time.deltaTime);
        }
        

    }

    void Start()
    {
        playerTarget = GameObject.Find("Player");
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
