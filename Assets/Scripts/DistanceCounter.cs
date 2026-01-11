using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    public Transform player; 

    private float startZ; 

    void Start() 
    { 
        startZ = player.position.z; 
    }

    void Update() 
    { 
        float distance = player.position.z - startZ; 
        UIManager.Instance.UpdateDistanceText(distance); 
    }
}
