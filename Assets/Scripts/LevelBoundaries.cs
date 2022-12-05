using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Daniel Lontz

public class LevelBoundaries : MonoBehaviour
{
    private GameObject playerTarget;
    private GameObject sword;
    public GameObject sheath;
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
        sword = GameObject.Find("Katana");
    
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "XR Origin")
        {
            onOutOfBoundsTrigger.Invoke();
        }
        if (col.gameObject.name == "Katana")
        {
            sword.transform.position = sheath.transform.position;
        }
    }

}
