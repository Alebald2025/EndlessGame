using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private Transform player;
    public float distanceBehind = 20f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player == null) return; 

        if (player.position.z - transform.position.z > distanceBehind)
        {
            Destroy(gameObject);
        }
    }
}
