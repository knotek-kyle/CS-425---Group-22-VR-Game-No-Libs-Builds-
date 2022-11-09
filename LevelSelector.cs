using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kyle Knotek

public class LevelSelector : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}
