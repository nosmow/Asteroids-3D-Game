using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnsPrefabs = new List<GameObject>();
    [SerializeField] List<Transform> points = new List<Transform>();
    [SerializeField] float timeSpawn = 2f;

    Vector3 spawnDirection;

    float timer = 0f;
    int randomIndex, posRandomIndex;
    float randomScalePrefab;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, 2f);
    }

    [ContextMenu ("Put Meteorite")]
    void SpawnObstacle()
    {

        randomIndex = Random.Range(0, spawnsPrefabs.Count);
        posRandomIndex = Random.Range(0, points.Count);
        randomScalePrefab = Random.Range(60f, 200f);

        spawnsPrefabs[randomIndex].transform.localScale = new Vector3(randomScalePrefab, randomScalePrefab, randomScalePrefab);
        
        Instantiate(spawnsPrefabs[randomIndex], points[posRandomIndex].position, points[posRandomIndex].rotation);
    }
}
