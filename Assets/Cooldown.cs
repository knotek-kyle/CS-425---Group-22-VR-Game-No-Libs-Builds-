using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class Cooldown : MonoBehaviour
{
    public float length;
    public GameObject subject;

    public void StartCooldown() 
    {
        subject.SetActive(false);
        Invoke(nameof(EndCooldown), length);
    }

    public void EndCooldown()
    {
        subject.SetActive(true);
    }
}
