using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//Kyle Knotek

public class ContinuousMovement : MonoBehaviour
{

    [Header("Movement\n")]
    public XRNode inputSource;
    public XROrigin xrOrigin;
    public Transform targetCamera;
    public Transform orientation;
    Vector3 moveDirection;

    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float dashSpeed;

    public float groundDrag;

    [Header("Jumping\n")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;
    public AudioSource jumpSound;

    [Header("Controls\n")]

    public InputActionProperty jumpButton;
    public InputActionProperty sprintButton;


    [Header("Ground Check\n")]
    public Transform FeetTransform;
    public LayerMask isGround;
    bool grounded;
    public bool dashing;

    private Vector2 inputAxis;
    public Rigidbody rb;
    private new CapsuleCollider collider;

    //Movement States
    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        dashing,
        air
    }

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        //Rotate player orientation according to camera
        orientation.eulerAngles = new Vector3(0, targetCamera.eulerAngles.y, 0);
        //Ground check
        grounded = Physics.CheckSphere(FeetTransform.position, 0.3f, isGround);

        SpeedControl();
        StateHandler();

        //ground drag
        if(state == MovementState.walking || state == MovementState.sprinting)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //Change Collider Height
        var center = xrOrigin.CameraInOriginSpacePos;
        //collider.center = new Vector3(center.x, GetComponent<Collider>().center.y, center.z);
        collider.height = xrOrigin.CameraInOriginSpaceHeight;

        //get jump press
        if(jumpButton.action.WasPressedThisFrame() && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void FixedUpdate()
    {
        //Get axis values from joystick
        UnityEngine.XR.InputDevice device = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out inputAxis);

        //create movement vectors
        moveDirection = orientation.forward * inputAxis.y + orientation.right * inputAxis.x;
        //(inputAxis.x, 0, inputAxis.y);

        //Call movement function
        MovePlayer(moveDirection);


    }

    private void StateHandler()
    {
        //Mode - Dashing
        if(dashing)
        {
            state = MovementState.dashing;
            moveSpeed = dashSpeed;
        }

        //Mode - Sprinting
        else if(grounded && sprintButton.action.IsPressed())
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        //Mode - Walking
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        //Mode - Air
        else
        {
            state = MovementState.air;
        }
    }

    private void MovePlayer(Vector3 moveDirection)
    {
        //ground movement
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Impulse);
        //air movement
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Impulse);

        //Keyboard control
        //rb.AddForce(moveDirectionK * moveSpeed, ForceMode.Force);
    }

    private void SpeedControl()
    {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limit velocity
            if(flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        jumpSound.Play(0);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
