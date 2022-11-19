using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class RotateSkybox : MonoBehaviour
{
    public float RotateSpeed = 1.2f;
 
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);
    }
}
