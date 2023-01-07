using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class RotateSelf : MonoBehaviour
{
    public float X;
    public float Y;
    public float Z;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(X * Time.deltaTime, Y * Time.deltaTime, Z * Time.deltaTime);
    }
}
