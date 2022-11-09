//Kyle Knotek

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSword : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
