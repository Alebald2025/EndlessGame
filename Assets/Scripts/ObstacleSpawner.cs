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
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        float xPos = 0f;

        if (!prefab.CompareTag("JumpObstacle")) 
        { 
            int lane = Random.Range(0, 3); 
            xPos = (lane - 1) * 2f; 
        }

        Vector3 spawnPos = new Vector3(xPos, 0, transform.position.z + spawnDistance); 

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
