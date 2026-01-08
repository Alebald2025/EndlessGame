using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; 
    public float spawnDistance = 20f; 
    public float spawnInterval = 2f;

    private float timer; 

    void Update() { 
        timer += Time.deltaTime; 
        if (timer >= spawnInterval) 
        { 
            timer = 0; 
            SpawnObstacle(); 
        } 
    }
    void SpawnObstacle() 
    { 
        int lane = Random.Range(0, 3); 
        float laneX = (lane - 1) * 2f; 
        Vector3 spawnPos = new Vector3(laneX, 0.513f, transform.position.z + spawnDistance); 
        Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPos, Quaternion.identity); 
    }
}
