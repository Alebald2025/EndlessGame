using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LaneScanner
{
    public static List<int> GetFreeLanes(float zPosition, float checkRange = 2f)
    {
        List<int> occupied = new List<int>(); 

        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); 

        foreach (var obs in obstacles) 
        { 
            if (Mathf.Abs(obs.transform.position.z - zPosition) < checkRange) 
            {
                if (!occupied.Contains(obs.lane)) occupied.Add(obs.lane); 
            } 
        } 
        
        List<int> free = new List<int>() { 0, 1, 2 }; 
        
        foreach (int lane in occupied) 
            free.Remove(lane); 

        return free; 
    }
    
}
