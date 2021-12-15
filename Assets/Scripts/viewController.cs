using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class viewController : MonoBehaviour
{
    [Header("UI")]

    public Text preLoadText;
    [SerializeField] Text HP;
    [SerializeField] Text enemiesCountText;

    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject pausePanel;
    public GameObject pauseButton;
    [SerializeField] Text resultText;
    [SerializeField] TextMeshProUGUI HPText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Text highscoreText;

    [HideInInspector] public bool isPause;

    private void Awake()
    {
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
        Time.timeScale = 0f;
        HP.gameObject.SetActive(false);
        enemiesCountText.gameObject.SetActive(false);

        restartPanel.SetActive(true);
        pauseButton.SetActive(false);

        if (FindObjectOfType<BaseHealth>().health>0)
        {
            resultText.text = "Поздравляем. Вы победили!";
        }
        else 
        {
            resultText.text = "Не отчаиваяйся, получится в следующий раз!";
        }

        HPText.text = FindObjectOfType<BaseHealth>().health.ToString();
        scoreText.text = (gameController.defeatEnemies - FindObjectOfType<BaseHealth>().startHealth+ FindObjectOfType<BaseHealth>().health).ToString();
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
       /* if (FindObjectOfType<MenuSettings>())
        {
            MenuSettings menusettings = FindObjectOfType<MenuSettings>();
            DestroyObject(menusettings.gameObject);
        }*/
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
