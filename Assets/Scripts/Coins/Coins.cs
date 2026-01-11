using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value = 1; 
    void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Player")) 
        { 
            CoinManager.Instance.AddCoins(value); 
            Destroy(gameObject); 
        }
    }
}
