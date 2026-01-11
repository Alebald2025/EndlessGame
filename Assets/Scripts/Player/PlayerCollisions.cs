using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerCrouch crouch; 
    private PlayerJump jump; 
    void Start()
    { 
        crouch = GetComponent<PlayerCrouch>(); 
        jump = GetComponent<PlayerJump>();
    }
    private void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Obstacle")) 
        { 
            Debug.Log("Game Over"); 
        } 
        if (other.CompareTag("JumpObstacle") && jump.isGrounded) 
        { 
            Debug.Log("Debías saltar → Game Over"); 
        } 
        if (other.CompareTag("CrouchObstacle") && !crouch.isCrouching) 
        { 
            Debug.Log("Debías agacharte → Game Over"); 
        } 
    }
}
