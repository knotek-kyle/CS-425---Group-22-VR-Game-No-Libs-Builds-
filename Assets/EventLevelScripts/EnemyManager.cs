using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Daniel Lontz
namespace EventCallbacks
{
public class EnemyManager : MonoBehaviour
{
    int enemyTotal;
    public GameObject enemy;
    private List<GameObject> enemyList;
    // Start is called before the first frame update


    void Start()
    {
        //contains list of all current enemies.  dead enemies are removed from list.
        enemyList = new List<GameObject>();
    }



    private void OnUnitSliced(object sender, SwordSlicer.UnitSliceEventInfo e) 
    {
        Debug.Log("Alerted about slice: " + e.UnitGO);
        Debug.Log(e.UnitGO.name + " being removed from enemy list");
        enemyList.Remove(e.UnitGO);
        e.UnitGO.GetComponent<EnemyLogic>().Die();   
    }


    private void RemoveAllEnemies(object sender, WinArea.WinConditionEventInfo e)
    {
        foreach (var go in enemyList)
        {
            Debug.Log("removed" + go.name + "from enemy list");
            Destroy(go);
        }
        enemyList.Clear();
    }


    void Spawn()
    {
        var newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10.0f, 10.0f),1,Random.Range(-10.0f, 10.0f)), Quaternion.identity);
        newEnemy.tag = "Enemy";
        enemyList.Add(newEnemy);
    }


    private void OnEnable()
    {
        WinArea.OnWin += RemoveAllEnemies;
        SwordSlicer.OnSlice += OnUnitSliced;
    }

    private void OnDisable()
    {
        WinArea.OnWin -= RemoveAllEnemies;
        SwordSlicer.OnSlice += OnUnitSliced;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            Spawn();
        }
    }
}
}