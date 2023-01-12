using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour , IDataPersistence
{
    private int score = 0;
    [SerializeField]public TextMeshProUGUI Score;

    public void LoadData(PlayerData data){
        this.score = data.score;
    }

    public void SaveData(ref PlayerData data){
        data.score = this.score;
    }

    public void Update(){
        if (Input.GetButtonDown("Fire1")){
            score ++;
        }
        Score.text = "" + score;
    }
}
