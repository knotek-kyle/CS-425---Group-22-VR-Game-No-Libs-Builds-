using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public float moveForce;
    public GameObject bullet;
    public Transform barrel;
    public float shootRate;
    public float shootForce;
    private float m_shootRateTimeStamp;
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        // null    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
