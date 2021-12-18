using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public int enemiesCount = 10;
    public float enemyHealth;
    public float damageByBullet;

    [SerializeField] float enSpeed = 4f;

    [SerializeField] float startSpawnDelay = 4f;
    [SerializeField] float finalSpawnDelay = 2f;
    [SerializeField] float deltaSpawnDelay = 0.2f;
    float crntSpawnDelay;
    [HideInInspector] public bool isSpawning;

    [SerializeField] AudioClip sfxSpawn;

    [SerializeField] Text countEnemiesText;

    [SerializeField] GameObject enemyToSpawn;

    private void Awake()
    {
        crntSpawnDelay = startSpawnDelay;
        isSpawning = false;
    }
    void Start()
    {
      //  countEnemiesText.text = enemiesCount.ToString();
    }
    public void SpawnEnemies()
    { StartCoroutine(Spawn(enemiesCount)); }
    IEnumerator Spawn(int spawnCount)
    { 
        while (spawnCount > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(sfxSpawn, 0.05f);

            var enemy = Instantiate(enemyToSpawn, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            SetUpEnemy(enemy);



            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                countEnemiesText.text = "∞";

            }
            else
            {
                spawnCount--;
                countEnemiesText.text = spawnCount.ToString();
            }
            yield return new WaitForSeconds(crntSpawnDelay);
            crntSpawnDelay = Mathf.Clamp(crntSpawnDelay -= deltaSpawnDelay, finalSpawnDelay, crntSpawnDelay);
        }
    }

    private void SetUpEnemy(GameObject enemy)
    {
        EnemyDamage enemyDamage = enemy.GetComponent<EnemyDamage>();
        enemyDamage.enemyHealth = enemyHealth;
        enemyDamage.damageByBullet = damageByBullet;

        EnemyMovement enemySpeed = enemy.GetComponent<EnemyMovement>();
        enemySpeed.enemySpeed = enSpeed;
        
    }
}
