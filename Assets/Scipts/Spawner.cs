using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject toSpawn;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float spawnDist;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemies());
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = RandomizeSpawn();
        Instantiate(toSpawn, spawnPos, Quaternion.identity);
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    private Vector3 RandomizeSpawn()
    {
        float width = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        float height = mainCamera.orthographicSize * 2;

        Vector3 spawnPoint;
        int side = Random.Range(0, 4);

        switch(side)
        {
            case 0:
                spawnPoint = new Vector3(-width / 2 - spawnDist, Random.Range(-height / 2, height / 2), 0);
                break;
            case 1:
                spawnPoint = new Vector3(width / 2 + spawnDist, Random.Range(-height / 2, height / 2), 0);
                break;
            case 2:
                spawnPoint = new Vector3(Random.Range(-width / 2, width / 2), height / 2 + spawnDist, 0);
                break;
            case 3:
                spawnPoint = new Vector3(Random.Range(-width / 2, width / 2), -height / 2 - spawnDist, 0);
                break;
            default:
                spawnPoint = Vector3.zero;
                break;
        }

        return spawnPoint;
    }
}
