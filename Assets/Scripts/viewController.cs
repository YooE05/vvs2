using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class viewController : MonoBehaviour
{

    DataController dataController;
    [Header("UI")]

    public Text preLoadText;
    [SerializeField] Text HP;
    [SerializeField] Text enemiesCountText;

    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject pausePanel;
    public GameObject pauseButton;
    [SerializeField] Text resultText;
    [SerializeField] Text HPText;
    [SerializeField] Text scoreText;
    [SerializeField] Text highscoreText;

    [HideInInspector] public bool isPause;

    private void Awake()
    {
        dataController = FindObjectOfType<DataController>();
        isPause = true;
    }
    public void StartGame()
    {
        isPause = false;
        preLoadText.text = "";
        pauseButton.SetActive(true);
        HP.gameObject.SetActive(true);
        enemiesCountText.gameObject.SetActive(true);
    }
    public void ShowRestartPanel(GameController gameController)
    {
        int killedEnemy = gameController.defeatEnemies - 10;

        Time.timeScale = 0f;
        HP.gameObject.SetActive(false);
        enemiesCountText.gameObject.SetActive(false);

        restartPanel.SetActive(true);
        pauseButton.SetActive(false);

        if (FindObjectOfType<BaseHealth>().health > 0)
        {
            resultText.text = "Поздравляем. Вы победили!";

            if (dataController.getLevelScore(dataController.getLastLevelIndex()) < FindObjectOfType<BaseHealth>().health)
            {
                dataController.SetScore(FindObjectOfType<BaseHealth>().health);
                dataController.SaveData();
            }

        }
        else
        {
            resultText.text = "Не отчаиваяйся, получится в следующий раз!";
        }

        if (dataController.isSurvival)
        {
            if (dataController.survivalScore < killedEnemy)
            {
                dataController.survivalScore = killedEnemy;
                dataController.SaveData();
            }


            HPText.text = killedEnemy.ToString();
            scoreText.text = dataController.survivalScore.ToString();
        }
        else
        {
            HPText.text = FindObjectOfType<BaseHealth>().health.ToString();
            scoreText.text = dataController.getLevelScore(dataController.getLastLevelIndex()).ToString();
        }

    }


    public void ShowPausePanel()
    {

        pausePanel.SetActive(true);
        isPause = true;

        pauseButton.SetActive(false);

        Time.timeScale = 0f;
    }

    public void Resume()
    {

        Time.timeScale = 1;

        isPause = false;

        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        dataController.isSurvival = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
