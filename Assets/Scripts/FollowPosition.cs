using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class FollowPosition : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }
}
