using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kyle Knotek

public class QuitGame : MonoBehaviour
{
    public string levelName;
    
    public void OpenScene()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
