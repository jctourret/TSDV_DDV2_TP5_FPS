using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGiver_Spawn : MonoBehaviour
{
    public GameObject pointGivePrefab;
    Transform spawnLocation;
    float timer;
    int spawnInterval = 20;
    float maxSpawnCoordX = 10;
    float minSpawnCoordX = -10;
    float maxSpawnCoordZ = 10;
    float minSpawnCoordZ = -10;
    // Update is called once per frame
    void Update()
    {
        if (timer > spawnInterval)
        {
            GameObject go = Instantiate(pointGivePrefab).gameObject;
            go.transform.position = new Vector3(Random.Range(minSpawnCoordX, maxSpawnCoordX), 0.6f, Random.Range(minSpawnCoordZ, maxSpawnCoordZ));
            timer = 0;
        }
    }
}
