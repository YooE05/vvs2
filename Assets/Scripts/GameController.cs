using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text preLoadText;
     EnemySpawner enemySpawner;
     BaseHealth healthController;

    TowerFactory towerFactory;

   public  int defetEnemies=0;
    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        healthController = GetComponent<BaseHealth>();
        towerFactory = GetComponent<TowerFactory>();
    }
    void Start()
    {
        StartCoroutine(GameProcces());
    }

    IEnumerator GameProcces()
    {
        preLoadText.text = "Ready?";
        yield return new WaitForSeconds(3f);
        preLoadText.text = "GO";
        yield return new WaitForSeconds(1f);
        preLoadText.text = "";
        towerFactory.isSpawning = true;
        enemySpawner.SpawnEnemies();

        while (healthController.health > 0 && defetEnemies < enemySpawner.enemiesCount )
        {
            yield return null;
        }

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

            SaveScore();
            viewController.ShowRestartPanel();
*/
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
