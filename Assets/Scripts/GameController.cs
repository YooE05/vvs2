using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [HideInInspector] public EnemySpawner enemySpawner;
    public BaseHealth healthController;
    [SerializeField] viewController viewController;

    TowerFactory towerFactory;

    public int defeatEnemies = 0;
    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        towerFactory = GetComponent<TowerFactory>();
    }
    void Start()
    {
        StartCoroutine(GameProcces());
    }

    IEnumerator GameProcces()
    {
        /*  viewController.preLoadText.text = "Ready?";
          yield return new WaitForSeconds(3f);
          viewController.preLoadText.text = "GO";
          yield return new WaitForSeconds(1f);
  */
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

        /*      isEndOfGame = true;
              plMovement.isPause = true;

              lastStage = stage;
              stage = GameStage.ending;

              healthController.StopGame();
              //player.SetActive(false);

              SaveScore();*/

        viewController.ShowRestartPanel(FindObjectOfType<GameController>());


    }


    void Update()
    {

    }
}
