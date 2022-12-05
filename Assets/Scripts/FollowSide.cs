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

    public int delayEuler = 10;

    private Vector3 pos;
    private List<float> storedPositions;

    void Awake()
    {
        storedPositions = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + Vector3.up * offset.y
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;

        //pos = new Vector3(rotationX, target.eulerAngles.y + rotationY, rotationZ);
        
        storedPositions.Add(target.eulerAngles.y);
        
        if(storedPositions.Count > delayEuler)
        {
            //transform.eulerAngles.y = storedPositions[delayEuler];
            transform.eulerAngles = new Vector3(rotationX, storedPositions[0] + rotationY, rotationZ);
            storedPositions.RemoveAt(0);
        }
        
        
    }

}
