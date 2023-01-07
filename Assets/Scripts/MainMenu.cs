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
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("New Scene");
   }

    public void OnPreviousGameClicked(){
        DisableMenuButtons();
        SceneManager.LoadSceneAsync("New Scene");
        

    }

    private void DisableMenuButtons() 
    {
        NewGame.interactable = false;
        PreviousGame.interactable = false;
    }
   
}
