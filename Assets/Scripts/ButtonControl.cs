using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;

//Kyle Knotek

public class ButtonControl : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] public float jumpForce = 500.0f;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private LayerMask JumpableFloor;
    public XROrigin xrOrigin;
    public AudioSource audioData;
    public new CapsuleCollider collider;

    public Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        jumpActionReference.action.performed += OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        var center = xrOrigin.CameraInOriginSpacePos;
        collider.center = new Vector3(center.x, collider.center.y, center.z);
        collider.height = xrOrigin.CameraInOriginSpaceHeight;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!Physics.CheckSphere(FeetTransform.position, 1.0f, JumpableFloor))
        {
            return;
        }
        body.AddForce(Vector3.up * jumpForce);
        audioData.Play(0);
    }
}

