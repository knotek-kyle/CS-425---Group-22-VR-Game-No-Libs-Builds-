using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   
    public int score;
    public Vector3 position;
    public Quaternion rotation;
    public SerializableDictionary<string, bool> enemiesKilled;

    public PlayerData(){
        this.score = 0;
        position.Set(0,0.50f,0);
        enemiesKilled = new SerializableDictionary<string, bool>();
    }
    
}
