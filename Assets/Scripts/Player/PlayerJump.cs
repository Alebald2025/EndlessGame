using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f; 
    public bool isGrounded = true; 
    private Rigidbody rb; 
    private Animator animator;

    void Start() 
    { 
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
    }
    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) 
        {
            DoJump();
        } 
    }
    private void OnCollisionEnter(Collision collision) 
    { 
        if (collision.collider.CompareTag("Ground")) 
            isGrounded = true; 
    }

    void DoJump()
    {
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded =  false;
    }

    public void TryJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
