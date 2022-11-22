using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject playerTarget;
    public float speed;
    public float minimumDistance;

    
    public static event System.EventHandler<UnitDeathEventInfo> OnDeath;

    public class UnitDeathEventInfo : EventInfo
    {   
    public GameObject UnitGO;
    public UnitDeathEventInfo(GameObject go)
        {
            UnitGO = go;
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        playerTarget = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerTarget.transform.position) > minimumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speed * Time.deltaTime);
        }
        

    }


    void dieTrigger()
    {
        OnDeath?.Invoke(this, new UnitDeathEventInfo(this.gameObject));
    }



    public void Die()
    {
        dieTrigger();
        Destroy(gameObject);
    }
}
