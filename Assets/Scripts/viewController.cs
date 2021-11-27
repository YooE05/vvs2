using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class viewController : MonoBehaviour
{
    [Header("UI")]

    public TextMeshProUGUI gapText;
    public TextMeshProUGUI countdownText;

    public TextMeshProUGUI leftTunnelText;
    public TextMeshProUGUI rightTunnelText;
    public Animator animatorUI;
    public GameObject rotateSigns;
    public Image energyBar;

    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] Text resultText;
    [SerializeField] TextMeshProUGUI HPText;
    [SerializeField] TextMeshProUGUI energyText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;

    [SerializeField] GameController gameController;

/*
    public void ShowRestartPanel()
    {
        Time.timeScale = 0f;
        countdownText.text = "";
        gapText.text = "";

        restartPanel.SetActive(true);
        pauseButton.SetActive(false);

        if (gameController.plMovement.enterCollider.tag == "Finish")
        {
            resultText.text = "Поздравляем. Вы победили!";

        }
        else 
        {
            resultText.text = "Не отчаиваяйся, получится в следующий раз!";
            //взрыв корабля
        }

        HPText.text = gameController.healthController.m_CurrentHealth.ToString();
        energyText.text = ((int)gameController.energy).ToString();
        scoreText.text =  gameController.score.ToString();
        highscoreText.text =  gameController.highscore.ToString();
    }

    public void ShowPausePanel()
    {
        gameController.timer.Restart();
        pausePanel.SetActive(true);
        gameController.isPause = true;
        gameController.plMovement.isPause = true;

        pauseButton.SetActive(false);

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        gameController.timer.Stop();
        gameController.deltaTimeTunnel = gameController.timer.Elapsed.Seconds * 1f + gameController.timer.Elapsed.Milliseconds / 1000f;

        Time.timeScale = 1;

        gameController.isPause = false;
        gameController.plMovement.isPause = false;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        if (FindObjectOfType<MenuSettings>())
        {
            MenuSettings menusettings = FindObjectOfType<MenuSettings>();
            DestroyObject(menusettings.gameObject);
        }
        SceneManager.LoadScene("MenuScreen");
    }
*/
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
