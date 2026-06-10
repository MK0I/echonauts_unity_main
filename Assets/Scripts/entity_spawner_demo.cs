using System.Collections;
using UnityEngine;

public class entity_spawner_demo : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Enemy Entity")]
    public GameObject enemyPrefab;
    [Tooltip("Minimum Delay")]
    public float minSpawnDelay = 1f;
    [Tooltip("Maximum Delay")]
    public float maxSpawnDelay = 3f;

    void Start()
    {
        StartCoroutine(SpawnRoutine()); // Spawn Loop
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randomWaitTime = Random.Range(minSpawnDelay, maxSpawnDelay); // Randomizer

            yield return new WaitForSeconds(randomWaitTime); // Timer

            Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Spawn Position
        }
    }
}
