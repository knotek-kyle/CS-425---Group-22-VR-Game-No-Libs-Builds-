using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinArea : MonoBehaviour
{
    public GameObject playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.Find("Player");
    }

    public static event System.EventHandler<WinConditionEventInfo> OnWin;

    public class WinConditionEventInfo : EventInfo
    {   
        public WinConditionEventInfo(string eventDescription)
            {
                this.EventDescription = eventDescription;
            }
    }


    public void WinTrigger()
    {
        OnWin?.Invoke(this, new WinConditionEventInfo("Win condition achieved"));
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
        WinTrigger();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
