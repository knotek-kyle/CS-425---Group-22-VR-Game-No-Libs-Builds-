using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        EnemyLogic.OnDeath += EnemyLogic_OnDeath;
    }

    private void OnDisable()
    {
        EnemyLogic.OnDeath -= EnemyLogic_OnDeath;
    }
    
    public void EnemyLogic_OnDeath(object sender, EnemyLogic.UnitDeathEventInfo e)
    {
        Debug.Log("Unit " + e.UnitGO.name + "has died");
    }
}
