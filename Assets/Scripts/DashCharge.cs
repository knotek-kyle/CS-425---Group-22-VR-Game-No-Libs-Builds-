using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Kyle Knotek

public class DashCharge : MonoBehaviour
{
    public bool armed = false;
    public bool charged = false;
    public float slowdownFactor = 0.1f;
    public float slowDownLength = 2f;
    public AudioSource music;

    public UnityEvent onHandHover;
    public UnityEvent onHandRemove;
    // Start is called before the first frame update

    public void Arm()
    {
        armed = true;
    }

    public void Disarm()
    {
        armed = false;
    }

    public void Charge()
    {
        if (armed == true)
        {
            onHandHover.Invoke();
            Time.timeScale = slowdownFactor;
            music.pitch = 0.5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        
    }

    public void CancelCharge()
    {
        if (armed == true)
        {
            onHandRemove.Invoke();
            Time.timeScale = 1.0f;
            music.pitch = 1.0f;
            Time.fixedDeltaTime = 0.02f;
        }

    }
}
