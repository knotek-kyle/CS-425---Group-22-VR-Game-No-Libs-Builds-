using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour , IDataPersistence
{
    private int score = 0;
    private TextMeshProUGUI Score;

    private void Awake(){
        Score = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(PlayerData data){
        this.score = data.score;
    }

    public void SaveData(ref PlayerData data){
        data.score = this.score;
    }

    private void Update(){
         if (Input.GetButtonDown("Fire1")){
            score ++;
        }
        Score.text = "" + score;
    }
}
