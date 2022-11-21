using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsListener : MonoBehaviour
{
    GameObject playerTarget;
    public Vector3 OutOfBoundsSpawn;

    void Start()
    {
        playerTarget = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        LevelBoundaries.OnOutOfBounds += winCondition;
    }

    private void OnDisable()
    {
        LevelBoundaries.OnOutOfBounds -= winCondition;
    }

    private void winCondition(object sender, LevelBoundaries.OutOfBoundsEventInfo e)
    {
        Debug.Log(e.EventDescription);
        playerTarget.transform.position = OutOfBoundsSpawn;
        
    }
}
