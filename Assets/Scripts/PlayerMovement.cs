using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour , IDataPersistence
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void LoadData(PlayerData data){
        this.transform.position = data.position;
        this.transform.rotation = data.rotation;
        
    }

    public void SaveData(ref PlayerData data){
        data.position = this.transform.position;
        data.rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);       
        }

        
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f , ground );
    }

}
