using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelBoundaries : MonoBehaviour
{
    public GameObject playerTarget;
    public static event System.EventHandler<OutOfBoundsEventInfo> OnOutOfBounds;
    public UnityEvent onOutOfBoundsTrigger;

    public class OutOfBoundsEventInfo : EventInfo
    {   
        public OutOfBoundsEventInfo(string eventDescription)
            {
                this.EventDescription = eventDescription;
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.Find("XR Origin");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "XR Origin")
        {
            onOutOfBoundsTrigger.Invoke();
        }
    }

}
