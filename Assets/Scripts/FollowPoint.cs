//Kyle Knotek

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class FollowPoint : MonoBehaviour
{
    public Transform swordPivot;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = swordPivot.rotation;
    }
}
