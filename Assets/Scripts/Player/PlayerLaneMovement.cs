using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerLaneController : MonoBehaviour {

    public float laneDistance = 2f; // Distancia entre carriles
    public float moveSpeed = 10f;

    private int currentLane = 1;
    private Vector3 targetPosition;

    void Start() { 
        UpdateTargetPosition(); 
    }

    // Update is called once per frame
    void Update()
    { 
        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow)) 
            ChangeLane(-1); 
        if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow)) 
            ChangeLane(1);
                           
        transform.position = Vector3.MoveTowards( 
            transform.position, 
            targetPosition, 
            moveSpeed * Time.deltaTime 
        ); 
    }
    
    public void ChangeLane(int direction) {
        int newLane = currentLane + direction; 

        if (newLane < 0 || newLane > 2) 
            return; 
  
        currentLane = newLane;
        UpdateTargetPosition();
    }

    void UpdateTargetPosition() { 
        targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z); 
    }
}