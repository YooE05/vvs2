using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public int enemiesCount = 10;

   // [Range(0.1f, 60f)]
    [SerializeField]   float startSpawnDelay = 4f;
    [SerializeField]   float finalSpawnDelay = 2f;
    [SerializeField]   float deltaSpawnDelay = 0.2f;
    float crntSpawnDelay;

    [HideInInspector] public bool isSpawning;

    [SerializeField] AudioClip sfxSpawn;

    [SerializeField] Text countEnemiesText;

    [SerializeField] GameObject enemyToSpawn;

    private void Awake()
    {
        isSpawning = false;
        crntSpawnDelay = startSpawnDelay;
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            countEnemiesText.text = "∞";

        }
        else
        {
            countEnemiesText.text = enemiesCount.ToString();
        }
    }

    public void SpawnEnemies()
    { StartCoroutine(Spawn(enemiesCount)); }
    IEnumerator Spawn(int spawnCount)
    {


        while (spawnCount > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(sfxSpawn, 0.05f);
            Instantiate(enemyToSpawn, gameObject.transform.position, Quaternion.identity, gameObject.transform);

            if (SceneManager.GetActiveScene().name != "SampleScene")
            {
                spawnCount--;
                countEnemiesText.text = spawnCount.ToString();
            }
            yield return new WaitForSeconds(crntSpawnDelay);
            crntSpawnDelay=Mathf.Clamp(crntSpawnDelay-=deltaSpawnDelay,finalSpawnDelay,crntSpawnDelay);
        }
    }
}
