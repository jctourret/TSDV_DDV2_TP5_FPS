using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Bombs : MonoBehaviour
{
    public GameObject bombPrefab;
    Transform spawnLocation;
    float timer;
    int spawnInterval = 10;
    float maxSpawnCoordX = 10;
    float minSpawnCoordX = -10;
    float maxSpawnCoordZ = 10;
    float minSpawnCoordZ = -10;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnInterval)
        {
            GameObject go = Instantiate(bombPrefab).gameObject;
            go.transform.position = new Vector3(Random.Range(minSpawnCoordX, maxSpawnCoordX), 0.6f, Random.Range(minSpawnCoordZ, maxSpawnCoordZ));
            timer = 0;
        }
    }
}