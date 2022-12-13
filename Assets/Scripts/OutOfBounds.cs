using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Daniel Lontz

public class OutOfBounds : MonoBehaviour
{
    GameObject playerTarget;
    public Vector3 OutOfBoundsSpawn;

    void Start()
    {
        playerTarget = GameObject.Find("XR Origin");
    }

    #region Event Subscriptions

    public void OnEnable()
    {
        LevelBoundaries.OnOutOfBounds += winCondition;
    }

    public void OnDisable()
    {
        LevelBoundaries.OnOutOfBounds -= winCondition;
    }

    #endregion

    private void winCondition(object sender, OutOfBoundsEventInfo e)
    {
        Debug.Log(e.EventDescription);
        playerTarget.transform.position = OutOfBoundsSpawn;
        
    }

    public void teleport()
    {
        playerTarget.transform.position = OutOfBoundsSpawn;
        
    }
}
