using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject coinPrefab;
    public Transform player;

    public int minObstacles = 10;
    public float spawnDistanceAhead = 60f;
    public float spawnSpacing = 10f;

    private List<GameObject> activeObstacles = new List<GameObject>();

    void Update()
    {
        while (activeObstacles.Count < minObstacles)
        {
            float zPos = player.position.z + spawnDistanceAhead + activeObstacles.Count * spawnSpacing;
            SpawnObstacle(zPos);
        }

        CleanupObstacles();

    }

    void SpawnObstacle(float zPos)
    {
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        float xPos = 0f;
        int lane = 1;

        if (!prefab.CompareTag("FullLaneObstacle"))
        {
            lane = Random.Range(0, 3);
            xPos = (lane - 1) * 2f;
        }

        Vector3 spawnPos = new Vector3(xPos, 0, zPos);

        GameObject obstacle = Instantiate(prefab, spawnPos, Quaternion.identity);
        activeObstacles.Add(obstacle);

        Obstacle obs = obstacle.GetComponent<Obstacle>();

        if (obs != null)
        {
            obs.lane = lane;
        }

        SpawnCoinsAroundObstacle(zPos, lane, prefab.CompareTag("FullLaneObstacle"));
    }

    private void SpawnCoinsAroundObstacle(float zPos, int obstacleLane, bool isFullLane)
    {
        SpawnCoins(zPos - 3f);

        SpawnCoins(zPos + 3f);

        if (!isFullLane)
        {
            List<int> freeLanes = new List<int>() { 0, 1, 2 };
            freeLanes.Remove(obstacleLane);

            if (freeLanes.Count > 0)
            {
                int lane = freeLanes[Random.Range(0, freeLanes.Count)];
                float xPos = (lane - 1) * 2f;

                Instantiate(coinPrefab, new Vector3(xPos, 1f, zPos), Quaternion.identity);
            }
        }

    }

    void CleanupObstacles()
    {
        for (int i = activeObstacles.Count - 1; i >= 0; i--)
        {
            if (activeObstacles[i].transform.position.z < player.position.z - 5f)
            {
                Destroy(activeObstacles[i]);
                activeObstacles.RemoveAt(i);
            }
        }
    }

    void SpawnCoins(float zPos)
    {
        List<int> freeLanes = LaneScanner.GetFreeLanes(zPos);

        if (freeLanes.Count == 0)
            return;

        int lane = freeLanes[Random.Range(0, freeLanes.Count)];

        float xPos = (lane - 1) * 2f;

        Instantiate(coinPrefab, new Vector3(xPos, 1f, zPos), Quaternion.identity);

    }

}

