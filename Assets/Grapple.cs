using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kyle Knotek

public class Grapple : MonoBehaviour
{
    private Rigidbody rb;
    private ContinuousMovement pm;
    public Transform grappleDir;
    public int force;
    public AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<ContinuousMovement>();
    }

    // Update is called once per frame
    public void Sling()
    {
        pm.grappling = true;
        rb.AddForce(grappleDir.forward * force, ForceMode.Impulse);
        jumpSound.Play(0);
    }
}
