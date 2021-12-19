using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EMM
{
    public class LevelSelectMenuController : MonoBehaviour
    {
        [Header("UI References")]
        public Text LevelTitleText;
        public Text LevelDescriptionText;
        public Image LevelImage;

        public Text Score;
        public Text maxHealth;
        public Text survivalScore;

        [HideInInspector]
        public List<AllLevelsData> AllLevelsData = new List<AllLevelsData>();

        int _totalLevels;
        int _currentSelectedLevelCount;
        string _currentSelectedLevelSceneName;

        bool firstLoad;

        // Use this for initialization
        void Start()
        {
            survivalScore.text = FindObjectOfType<DataController>().survivalScore.ToString();
            //get all levels count
            _totalLevels = AllLevelsData.Count;

            //init
            firstLoad = true;
            _currentSelectedLevelCount = FindObjectOfType<DataController>().getLastLevelIndex();
            ChangeLevel();
        }

        public void ChangeLevel()
        {
            if (firstLoad)
            { firstLoad = false; }
            else
            {
                if (_currentSelectedLevelCount < _totalLevels - 1)
                    _currentSelectedLevelCount++;
                else
                    _currentSelectedLevelCount = 0;
                FindObjectOfType<DataController>().changeLastLevelIndex(_currentSelectedLevelCount);
            }

            switch (_currentSelectedLevelCount)
            {
                case 0:
                    { maxHealth.text = "10"; }
                    break;
                case 1:
                    { maxHealth.text = "5"; }
                    break;
                case 2:
                    { maxHealth.text = "5"; }
                    break;
                case 3:
                    { maxHealth.text = "5"; }
                    break;
                case 4:
                    { maxHealth.text = "5"; }
                    break;
                case 5:
                    { maxHealth.text = "3"; }
                    break;
                default:
                    break;
            }
            Score.text = FindObjectOfType<DataController>().getLevelScore(_currentSelectedLevelCount).ToString();

            //set UI
            LevelTitleText.text = AllLevelsData[_currentSelectedLevelCount].LevelTitle;
            LevelDescriptionText.text = AllLevelsData[_currentSelectedLevelCount].LevelDescription;
            LevelImage.sprite = AllLevelsData[_currentSelectedLevelCount].LevelSprite;
            _currentSelectedLevelSceneName = AllLevelsData[_currentSelectedLevelCount].SceneToLoad;

            //increment count
            /*if (_currentSelectedLevelCount < _totalLevels-1)
                _currentSelectedLevelCount++;
            else
                _currentSelectedLevelCount = 0;*/

            PlayClickSound();
        }
        public void ChangeLevelBack()
        {
            if (firstLoad)
            { firstLoad = false; }
            else
            {
                if (_currentSelectedLevelCount != 0)
                    _currentSelectedLevelCount--;
                else
                    _currentSelectedLevelCount = _totalLevels - 1;
                FindObjectOfType<DataController>().changeLastLevelIndex(_currentSelectedLevelCount);
            }

            switch (_currentSelectedLevelCount)
            {
                case 0:
                    { maxHealth.text = "10"; }
                    break;
                case 1:
                    { maxHealth.text = "5"; }
                    break;
                case 2:
                    { maxHealth.text = "5"; }
                    break;
                case 3:
                    { maxHealth.text = "5"; }
                    break;
                case 4:
                    { maxHealth.text = "5"; }
                    break;
                case 5:
                    { maxHealth.text = "3"; }
                    break;
                default:
                    break;
            }
            Score.text = FindObjectOfType<DataController>().getLevelScore(_currentSelectedLevelCount).ToString();
            //set UI
            LevelTitleText.text = AllLevelsData[_currentSelectedLevelCount].LevelTitle;
            LevelDescriptionText.text = AllLevelsData[_currentSelectedLevelCount].LevelDescription;
            LevelImage.sprite = AllLevelsData[_currentSelectedLevelCount].LevelSprite;
            _currentSelectedLevelSceneName = AllLevelsData[_currentSelectedLevelCount].SceneToLoad;

            //increment count
            /* if (_currentSelectedLevelCount!=0)
                 _currentSelectedLevelCount--;
             else
                 _currentSelectedLevelCount = _totalLevels-1;*/

            PlayClickSound();
        }


        void PlayClickSound()
        {
            if (EasyAudioUtility.instance)
                EasyAudioUtility.instance.Play(FindObjectOfType<MainMenuController>().ButtonClickSFX);
        }

        public void PlayLevel()
        {
            //open the level which is selected via level select
            PlayerPrefs.SetString("sceneToLoad", _currentSelectedLevelSceneName);

            //reset slot count
            PlayerPrefs.SetInt("slotLoaded_", -1);

            //load level via fader
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeIntoLevel("LoadingScreen");
        }

    }

    [System.Serializable]
    public class AllLevelsData
    {
        public string LevelTitle;
        public string LevelDescription;
        public string SceneToLoad;
        public Sprite LevelSprite;
    }
}