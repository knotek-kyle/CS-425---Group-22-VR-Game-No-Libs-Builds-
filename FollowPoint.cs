//Kyle Knotek

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class FollowPoint : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles = new Vector3(target.eulerAngles.x + 270, target.eulerAngles.y, target.eulerAngles.z);
        transform.rotation = target2.rotation;
    }
}
