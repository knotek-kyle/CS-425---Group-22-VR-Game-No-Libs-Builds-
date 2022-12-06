using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

    [Header("Menu Buttons")]
    [SerializeField] private Button NewGame;
    [SerializeField] private Button PreviousGame;


    public void OnNewGameClicked(){
        Debug.Log("New");
        
        SceneManager.LoadSceneAsync("SampleScene");
   }

    public void OnPreviousGameClicked(){
        DisableMenuButtons();
        SceneManager.LoadSceneAsync("SampleScene");
        

    }

    private void DisableMenuButtons() 
    {
        NewGame.interactable = false;
        PreviousGame.interactable = false;
    }
   
}
