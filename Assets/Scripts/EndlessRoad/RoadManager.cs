using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject roadTilePrefab; 
    public int numberOfTiles = 5; 
    public float tileLength = 30f;
    
    private List<GameObject> activeTiles = new List<GameObject>(); 
    public Transform player; 
    void Start() 
    {
        for (int i = 0; i < numberOfTiles; i++) 
        { 
            SpawnTile(i * tileLength); 
        } 
    }
    void Update()
    { 
        // Si el jugador ha pasado el segundo tile, instanciamos uno nuevo
        if (player.position.z - 35f > activeTiles[0].transform.position.z) 
        { 
            SpawnTile(activeTiles[activeTiles.Count - 1].transform.position.z + tileLength); DeleteTile(); 
        } 
    }
    void SpawnTile(float zPosition) 
    { 
        GameObject tile = Instantiate(roadTilePrefab, new Vector3(0, 0, zPosition), Quaternion.identity); 
        activeTiles.Add(tile); 
    } 
    
    void DeleteTile() 
    { 
        Destroy(activeTiles[0]); 
        activeTiles.RemoveAt(0); 
    }

}
