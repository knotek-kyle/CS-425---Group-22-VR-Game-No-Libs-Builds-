using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{
    public GameObject playerTarget;
    public static event System.EventHandler<OutOfBoundsEventInfo> OnOutOfBounds;

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
        playerTarget = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            OnOutOfBounds?.Invoke(this, new OutOfBoundsEventInfo("Player Out Of Bounds"));
        }
    }

}
