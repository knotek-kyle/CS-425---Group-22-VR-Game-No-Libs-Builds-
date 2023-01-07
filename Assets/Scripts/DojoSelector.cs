using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kyle Knotek

public class DojoSelector : MonoBehaviour
{
    public void OpenDJScene()
    {
        SceneManager.LoadScene("CutDojo");
    }
}
