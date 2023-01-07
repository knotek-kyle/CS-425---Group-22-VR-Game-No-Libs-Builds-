using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Kyle Knotek

public class PauseMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2;
    public GameObject menu;
    public InputActionProperty showButton;

    void Update()
    {
        if(showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }

        //menu.transform.position = head.position + new Vector3(head.forward.x, head.forward.z).normalized * spawnDistance;
        //menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        //menu.transform.forward *= -1;
    }
}
