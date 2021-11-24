using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int enemyCount = 5;
    [Range(0.1f, 60f)]
    [SerializeField]

    float spawnDelay = 2f;
    [SerializeField] GameObject enemyToSpawn;

    void Start()
    {
        StartCoroutine(Spawn(enemyCount));
    }

    IEnumerator Spawn(int spawnCount)
    {
        while (spawnCount > 0)
        {
            spawnCount--;
            Instantiate(enemyToSpawn, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
