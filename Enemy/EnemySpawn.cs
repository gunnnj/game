using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject objectToSpawn; // GameObject bạn muốn spawn
    public float spawnInterval = 2f; // Thời gian giữa các lần spawn


    private BoxCollider2D spawnArea;
    // Start is called before the first frame update
    void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnObject()
    {
        Vector2 spawnPosition = GetRandomPosition();
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
    Vector2 GetRandomPosition()
    {
        Vector2 min = spawnArea.bounds.min;
        Vector2 max = spawnArea.bounds.max;

        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);

        return new Vector2(randomX, randomY);
    }
}
