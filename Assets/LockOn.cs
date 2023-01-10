using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class LockOn : MonoBehaviour
{
    public int radius = 1;
    public LayerMask layer;
    Collider[] hitCollider;

    void Update()
    {
        hitCollider = Physics.OverlapSphere(transform.position, radius, layer);

        if(hitCollider.Length > 0)
        {
            Debug.Log("collided with" + hitCollider[0].name);
            transform.LookAt(hitCollider[0].transform.position);
        }
    }
}
