using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Kyle Knotek

public class Dash : MonoBehaviour
{
    [Header("Referneces")]
    public Transform orientation;
    public Transform playerCam;
    public Image abilityBar;
    private Rigidbody rb;
    private ContinuousMovement pm;
    public UnityEvent onOutOfBoundsTrigger;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    [Header("Particle Events")]
    public UnityEvent onDash;
    public UnityEvent onDashStop;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<ContinuousMovement>();
        abilityBar.fillAmount = 0;
    }

    private void Update()
    {
        if (dashCdTimer > 0)
            dashCdTimer -= Time.deltaTime;
        if(pm.dashing == false)
            abilityBar.fillAmount += 1/dashCd * Time.deltaTime;
    }

    public void DoDash()
    {
        if(dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        rb.velocity = new Vector3(0, 0, 0);
        pm.dashing = true;

        Vector3 forceToApply = playerCam.forward * dashForce + orientation.up * dashUpwardForce;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.1f);
        onDash.Invoke();
        abilityBar.fillAmount = 0;

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
        onDashStop.Invoke();

        rb.velocity = new Vector3(0, 0, 0);
    }
}
