using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        WinArea.OnWin += winCondition;
    }

    private void OnDisable()
    {
        WinArea.OnWin -= winCondition;
    }

    private void winCondition(object sender, WinArea.WinConditionEventInfo e)
    {
        Debug.Log(e.EventDescription);
        
    }

}
