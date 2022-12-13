using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //how many waves before ending encounter
    public int numberWaves;
    //randomly spawn the enemies in a radius around the spawner
    public bool isSpawnLocationRandom;
    //spawn the enemies randomly but in close proximity to each other
    public bool spawnInGroups;
    //can specify a specific enemy for last wave (boss?)
    public bool lastWaveSpecialEnemy;
    //max distance for enemy spawning. Only applicable to random spawning
    public int maxSpawnDistance;
    //max enemies that spawn per wave
    public int enemiesPerWave;
    //list of current enemies
    private List<GameObject> enemyList;
    //what enemy to spawn
    public GameObject enemyReference;
    //reference to the player
    public GameObject playerReference;
    //spawn origin of enemies
    public GameObject spawnLocationReference;
    
    private bool encounterStarted = false;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (encounterStarted == false)
            {
            Debug.Log("Encounter started");
            initEnemies();
            spawnWave();
            encounterStarted = true;
            }
            
        }
    }

    private void initEnemies()
    {
        enemyList = new List<GameObject>();
        for (int i = 0; i < enemiesPerWave; i++)
        {
            enemyList.Add(enemyReference);
        }
    }

    private void spawnWave()
    {
        Vector3 spawnLocation = new Vector3(spawnLocationReference.transform.position.x, spawnLocationReference.transform.position.y, spawnLocationReference.transform.position.z);

        foreach (var enemy in enemyList)
        {
            if (isSpawnLocationRandom)
            {
            float randomX = Random.Range(-3.0f, 3.0f);
            float randomZ = Random.Range(-3.0f, 3.0f);
            spawnLocation.x = spawnLocation.x + randomX;
            spawnLocation.z = spawnLocation.z + randomZ;
            }
            Instantiate(enemy, spawnLocation, spawnLocationReference.transform.rotation);
        }
    }



}
