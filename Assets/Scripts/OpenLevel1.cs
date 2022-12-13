using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel1 : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("CityTest");
    }
}
