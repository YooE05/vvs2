using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    DataController dataController;
    [HideInInspector] public EnemySpawner enemySpawner;
    public BaseHealth healthController;
    [SerializeField] viewController viewController;

    TowerFactory towerFactory;

    public int defeatEnemies = 0;
    private void Awake()
    {
        dataController = FindObjectOfType<DataController>();
        enemySpawner = GetComponent<EnemySpawner>();
        towerFactory = GetComponent<TowerFactory>();
    }
    void Start()
    {
        foreach (var audio in FindObjectsOfType<AudioSource>())
        {
            audio.volume = audio.volume * dataController.volume;
        }

        StartCoroutine(GameProcces());
    }

    IEnumerator GameProcces()
    {
          viewController.preLoadText.text = "Ready?";
          yield return new WaitForSeconds(3f);
          viewController.preLoadText.text = "GO";
          yield return new WaitForSeconds(1f);
  
        viewController.StartGame();

        //towerFactory.isSpawning = true;
        enemySpawner.SpawnEnemies();

        while (healthController.health > 0 && defeatEnemies < enemySpawner.enemiesCount)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        Debug.Log("END");
        EndGame();
    }

    void EndGame()
    {

        viewController.ShowRestartPanel(FindObjectOfType<GameController>());

    }


    void Update()
    {

    }
}
