using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour , IDataPersistence
{
    [SerializeField] GameObject e;
    [SerializeField] private string id ;
    private bool killed = false;
    

    [ContextMenu("Generate guid for id")]


    private void GenerateGuid(){
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(PlayerData data){
        data.enemiesKilled.TryGetValue( id , out killed);
        if(killed){
            Destroy(e);
        }
        
    }

    public void SaveData(ref PlayerData data){
        if(data.enemiesKilled.ContainsKey(id)){
            data.enemiesKilled.Remove(id);
        }
        data.enemiesKilled.Add(id, killed);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Bullet"){
            Destroy(e);
            Destroy(collision.gameObject);
            killed = true;
        }
        if(collision.gameObject.name == "Katana"){
            Destroy(e);
            killed = true;
        }
    }
}
