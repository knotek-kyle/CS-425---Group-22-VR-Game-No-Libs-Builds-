using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Referneces")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private ContinuousMovement pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<ContinuousMovement>();
    }

    private void Update()
    {
        if (dashCdTimer > 0)
            dashCdTimer -= Time.deltaTime;
    }

    public void DoDash()
    {
        if(dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        pm.dashing = true;

        Vector3 forceToApply = playerCam.forward * dashForce + orientation.up * dashUpwardForce;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.02f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private Vector3 delayedForceToApply;

    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        pm.dashing = false;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
