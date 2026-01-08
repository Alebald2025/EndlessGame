using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f; 
    public bool isGrounded = true; 
    private Rigidbody rb; 
    void Start() 
    { 
        rb = GetComponent<Rigidbody>(); 
    }
    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) 
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isGrounded = false; 
        } 
    }
    private void OnCollisionEnter(Collision collision) 
    { 
        if (collision.collider.CompareTag("Ground")) isGrounded = true; 
    }
}
