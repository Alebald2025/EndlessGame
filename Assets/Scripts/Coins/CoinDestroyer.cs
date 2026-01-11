using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    public Transform player; 

    void Update() 
    { 
        if (transform.position.z < player.position.z - 5f) 
            Destroy(gameObject); 
    }
}
