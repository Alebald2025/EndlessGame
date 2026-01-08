using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public float crouchScale = 0.5f; 
    public float crouchDuration = 2f; 
    public bool isCrouching = false; 
    private Vector3 originalScale; 
    void Start() 
    { 
        originalScale = transform.localScale; 
    }
    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isCrouching)
            StartCoroutine(CrouchRoutine()); 
    }
    IEnumerator CrouchRoutine() 
    { 
        isCrouching = true; 
        transform.localScale = originalScale * crouchScale; 
        yield return new WaitForSeconds(crouchDuration); 
        transform.localScale = originalScale; 
        isCrouching = false; 
    }
}
