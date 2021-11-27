using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public  int enemiesCount = 10;

    [Range(0.1f, 60f)]
    [SerializeField]
    float spawnDelay = 2f;
    [HideInInspector] public bool isSpawning;

    [SerializeField] AudioClip sfxSpawn;

    [SerializeField] Text countEnemiesText;

    [SerializeField] GameObject enemyToSpawn;

    private void Awake()
    {
        isSpawning = false;
    }
    void Start()
    {     
        countEnemiesText.text = enemiesCount.ToString();
    }

    public void SpawnEnemies()
    { StartCoroutine(Spawn(enemiesCount)); }
     IEnumerator Spawn(int spawnCount)
    {
        while (spawnCount > 0)
        {
                GetComponent<AudioSource>().PlayOneShot(sfxSpawn, 0.05f);
                spawnCount--;
                Instantiate(enemyToSpawn, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                countEnemiesText.text = spawnCount.ToString();
                yield return new WaitForSeconds(spawnDelay);
        }
    }
}
