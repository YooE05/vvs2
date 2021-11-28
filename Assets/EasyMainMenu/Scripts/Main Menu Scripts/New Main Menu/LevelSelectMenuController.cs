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

        [HideInInspector]
        public List<AllLevelsData> AllLevelsData = new List<AllLevelsData>();

        int _totalLevels;
        int _currentSelectedLevelCount;
        string _currentSelectedLevelSceneName;

        bool firstLoad;

        // Use this for initialization
        void Start()
        {
            //get all levels count
            _totalLevels = AllLevelsData.Count;

            //init
            firstLoad= true;
            _currentSelectedLevelCount = FindObjectOfType<DontDestroySettings>().getLastLevelIndex();
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
                FindObjectOfType<DontDestroySettings>().changeLastLevelIndex(_currentSelectedLevelCount);
            }
            
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
                FindObjectOfType<DontDestroySettings>().changeLastLevelIndex(_currentSelectedLevelCount);
            }
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