using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSide : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public int rotationX;
    public int rotationY;
    public int rotationZ;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + Vector3.up * offset.y
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;

        transform.eulerAngles = new Vector3(rotationX, target.eulerAngles.y + rotationY, rotationZ);
    }
}
