using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 10f; 
    public Vector3 offset;

    void LateUpdate()
    { 
        Vector3 targetPosition = new Vector3( 
            0f, 
            player.position.y + offset.y, 
            player.position.z + offset.z   
        ); 
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); }
    }
