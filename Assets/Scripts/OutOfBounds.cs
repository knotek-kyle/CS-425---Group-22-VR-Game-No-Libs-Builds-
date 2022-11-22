using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    GameObject playerTarget;
    public Vector3 OutOfBoundsSpawn;

    void Start()
    {
        playerTarget = GameObject.Find("XR Origin");
    }

    public void OnEnable()
    {
        LevelBoundaries.OnOutOfBounds += winCondition;
    }

    public void OnDisable()
    {
        LevelBoundaries.OnOutOfBounds -= winCondition;
    }

    private void winCondition(object sender, LevelBoundaries.OutOfBoundsEventInfo e)
    {
        Debug.Log(e.EventDescription);
        playerTarget.transform.position = OutOfBoundsSpawn;
        
    }

    public void teleport()
    {
        playerTarget.transform.position = OutOfBoundsSpawn;
        
    }
}
