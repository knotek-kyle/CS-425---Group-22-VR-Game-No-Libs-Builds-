using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

///Daniel Lontz
///<summary>
///creates an OutOfBounds event when "Player" collider enters this object's collider
///</summary> 

public class LevelBoundaries : MonoBehaviour
{
    private GameObject playerTarget;
    private GameObject sword;
    public GameObject sheath;
    //probably shouldn't be using both UnityEvent with C# events, we should choose
    //one and stick with it
    public static event System.EventHandler<OutOfBoundsEventInfo> OnOutOfBounds;
    public UnityEvent onOutOfBoundsTrigger;

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
