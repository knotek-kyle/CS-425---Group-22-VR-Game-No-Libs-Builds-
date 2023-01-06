using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climbing : MonoBehaviour
{
    private Rigidbody rb;
    public static XRController climbHand;
    private ContinuousMovement pm;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<ContinuousMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(climbHand)
        {
            Debug.Log("Climb Enter");
            pm.enabled = false;
            Climb();
        }
        else{
            pm.enabled = true;
        }
    }

    //Climbing calculations
    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        rb.AddForce(transform.rotation *-velocity, ForceMode.Impulse);
    }
}
