using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private Vector2 startTouch; 
    private bool isSwiping = false; 
    
    public float swipeThreshold = 50f; 
    
    public PlayerLaneController laneMovement; 
    public PlayerJump jump; 

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0); 

            if (t.phase == TouchPhase.Began) 
            { 
                isSwiping = true; 
                startTouch = t.position; 
            }
            else if (t.phase == TouchPhase.Moved && isSwiping)
            {
                Vector2 delta = t.position - startTouch; 
                
                if (Mathf.Abs(delta.x) > swipeThreshold)
                { 
                    if (delta.x > 0) 
                        laneMovement.ChangeLane(1);
                    else 
                        laneMovement.ChangeLane(-1); 
                        
                    isSwiping = false; 
                } 
                else if (Mathf.Abs(delta.y) > swipeThreshold) 
                { 
                    if (delta.y > 0) 
                        jump.TryJump();                        
                    isSwiping = false; 
                } 
            } 
            else if (t.phase == TouchPhase.Ended) 
            { 
                isSwiping = false; 
            
            } 
        } 
    }
                
}
