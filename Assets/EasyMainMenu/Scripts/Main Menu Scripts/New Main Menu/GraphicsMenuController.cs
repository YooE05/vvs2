using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EMM
{
    public class GraphicsMenuController : MonoBehaviour
    {
        public Text TextureQualityValue; 
        public Text AntiAliasingValue; 
        public Text ShadowsValue; 
        public Text VSyncValue; 
        public Text ResolutionValue;

        [Space]
        public List<Vector2> AllResolutions = new List<Vector2>();

        int width;
        int height;

        // Use this for initialization
        void Start()
        {
            InitializeOptionsMenu();

            if (EasyAudioUtility.instance == null)
                Instantiate(Resources.Load("Prefabs/EasyAudioUtility"));
        }

        /// <summary>
        /// Init all the previously stored settings
        /// </summary>
        void InitializeOptionsMenu()
        {
            GetSetTextureQuality();
            GetSetAntiAliasing();
            GetSetShadows();
            GetSetVSync();

            RetrieveAllResolutions();
            GetSetResolution();
        }

        #region Texture Quality

        void GetSetTextureQuality()
        {
            int i = PlayerPrefs.GetInt("MFPS_masterTextureLimit", 0);

            switch (i)
            {

                //ULTRA
                case 00:
                    TextureQualityValue.text = "Ультра";
                    break;

                //HIGH
                case 01:
                    TextureQualityValue.text = "Высокие";
                    break;

                //MEDIUM
                case 02:
                    TextureQualityValue.text = "Средние";
                    break;

                //LOW
                case 03:
                    TextureQualityValue.text = "Низкие";
                    break;

            }

            QualitySettings.masterTextureLimit = i;
        }

        public void ChangeTextureQuality()
        {
            int i = QualitySettings.masterTextureLimit;

            switch (i) {

                //ULTRA
                case 00:
                    i = 1;
                    TextureQualityValue.text = "Высокие";
                    break;

                //HIGH
                case 01:
                    i = 2;
                    TextureQualityValue.text = "Средние";
                    break;

                //MEDIUM
                case 02:
                    i = 3;
                    TextureQualityValue.text = "Низкие";
                    break;

                //LOW
                case 03:
                    i = 0;
                    TextureQualityValue.text = "Ультра";
                    break;

            }

            QualitySettings.masterTextureLimit = i;

            //SAVE
            PlayerPrefs.SetInt("MFPS_masterTextureLimit", i);

            //play click sound
            if (EasyAudioUtility.instance)
                EasyAudioUtility.instance.Play(FindObjectOfType<MainMenuController>().ButtonClickSFX);
        }

        #endregion

        #region Anti Aliasing

        void GetSetAntiAliasing()
        {
            int i = PlayerPrefs.GetInt("MFPS_antiAliasing", 0);

            switch (i)
            {
                //DISABLED
                case 00:
                    AntiAliasingValue.text = "Выкл";
                    break;

                //2X
                case 02:
                    AntiAliasingValue.text = "2X";
                    break;

                //4X
                case 04:
                    AntiAliasingValue.text = "4X";
                    break;

                //8X
                case 08:
                    AntiAliasingValue.text = "8X";
                    break;
            }

            QualitySettings.antiAliasing = i;
        }

        public void ChangeAntiAliasing()
        {
            int i = PlayerPrefs.GetInt("MFPS_antiAliasing", 0);

            switch (i)
            {
                //DISABLED
                case 00:
                    i = 2;
                    AntiAliasingValue.text = "2X";
                    break;

                //2X
                case 02:
                    i = 4;
                    AntiAliasingValue.text = "4X";
                    break;

                //4X
                case 04:
                    i = 8;
                    AntiAliasingValue.text = "8X";
                    break;

                //8X
                case 08:
                    i = 0;
                    AntiAliasingValue.text = "Выкл";
                    break;
            }

            QualitySettings.antiAliasing = i;

            //SAVE
            PlayerPrefs.SetInt("MFPS_antiAliasing", i);

            //play click sound
            if (EasyAudioUtility.instance)
                EasyAudioUtility.instance.Play(FindObjectOfType<MainMenuController>().ButtonClickSFX);

        }

        #endregion

        #region Shadows

        void GetSetShadows()
        {
            string i = "";
            i = PlayerPrefs.GetString("MFPS_Shadows", "All");

            switch (i)
            {
                //DISABLED
                case "Disable":
                    ShadowsValue.text = "Выкл";
                    QualitySettings.shadows = ShadowQuality.Disable;
                    break;

                //HARD
                case "HardOnly":
                    ShadowsValue.text = "Жёстк";
                    QualitySettings.shadows = ShadowQuality.HardOnly;
                    break;

                //HARD & SOFT
                case "All":
                    ShadowsValue.text = "Жёстк & Мягк";
                    QualitySettings.shadows = ShadowQuality.All;
                    break;
            }
        }

        public void ChangeShadows()
        {
            string i = "";
            i = PlayerPrefs.GetString("MFPS_Shadows", "All");

            switch (i)
            {
                //DISABLED
                case "Disable":
                    i = "HardOnly";
                    ShadowsValue.text = "Жёстк";
                    QualitySettings.shadows = ShadowQuality.HardOnly;
                    break;

                //HARD
                case "HardOnly":
                    i = "All";
                    ShadowsValue.text = "Жёстк & Мягк";
                    QualitySettings.shadows = ShadowQuality.All;
                    break;

                //HARD & SOFT
                case "All":
                    i = "Disable";
                    ShadowsValue.text = "Выкл";
                    QualitySettings.shadows = ShadowQuality.Disable;
                    break;
            }

            //SAVE
            PlayerPrefs.SetString("MFPS_Shadows", i);

            //play click sound
            if (EasyAudioUtility.instance)
                EasyAudioUtility.instance.Play(FindObjectOfType<MainMenuController>().ButtonClickSFX);
        }

        #endregion

        #region V Sync

        void GetSetVSync()
        {
            int i = PlayerPrefs.GetInt("MFPS_VSync", 0);

            switch (i)
            {
                //DISABLED
                case 00:
                    VSyncValue.text = "Выкл";
                    break;

                //ENABLED
                case 01:
                    VSyncValue.text = "Вкл";
                    break;

            }

            QualitySettings.vSyncCount = i;

        }

        public void ChangeVSync()
        {
            int i = PlayerPrefs.GetInt("MFPS_VSync", 0);

            switch (i)
            {
                //DISABLED
                case 00:
                    i = 1;
                    VSyncValue.text = "Вкл";
                    break;

                //ENABLED
                case 01:
                    i = 0;
                    VSyncValue.text = "Выкл";
                    break;

            }

            QualitySettings.vSyncCount = i;

            //SAVE
            PlayerPrefs.SetInt("MFPS_VSync", i);

            //play click sound
            if (EasyAudioUtility.instance)
                EasyAudioUtility.instance.Play(FindObjectOfType<MainMenuController>().ButtonClickSFX);

        }

        #endregion

        #region Resolution

        /// <summary>
        /// Get all resolutions
        /// </summary>
        void RetrieveAllResolutions()
        {
            //search all resolutions
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                //get one by one each
                Vector2 res = new Vector2(Screen.resolutions[i].width, Screen.resolutions[i].height);

                //make sure it is not already added in the list of resolutions
                if (!AllResolutions.Contains(res))
                    AllResolutions.Add(res);
            }
        }

        public void GetSetResolution()
        {
            width = PlayerPrefs.GetInt("MFPS_Width", Screen.currentResolution.width);
            height = PlayerPrefs.GetInt("MFPS_Height", Screen.currentResolution.height);

            //set the resolution
            Screen.SetResolution(width, height, true);
            ResolutionValue.text = width + " X " + height;

           
        }

        public void ChangeResolution()
        {
            int w = width;
            int h = height;

            for(int i =0; i < AllResolutions.Count; i++)
            {
                //set next resolution
                if(AllResolutions[i].x == w && AllResolutions[i].y == h)
                {
                    if(i+1 < AllResolutions.Count)
                    {
                        w = (int)AllResolutions[i+1].x;
                        h = (int)AllResolutions[i+1].y;

                        //exit from loop
                        break;
                    }
                    else
                    {
                        w = (int)AllResolutions[0].x;
                        h = (int)AllResolutions[0].y;

                        //exit from loop
                        break;
                    }

                }
            }

            //set ui text
            ResolutionValue.text = w + " X " + h;

            width = w;
            height = h;

            //play click sound
            if (EasyAudioUtility.instance)
                EasyAudioUtility.instance.Play(FindObjectOfType<MainMenuController>().ButtonClickSFX);
        }

        public void SetResolution()
        {
            //set the resolution
            Screen.SetResolution(width, height, true);

            //SAVE
            PlayerPrefs.SetInt("MFPS_Width", width);
            PlayerPrefs.SetInt("MFPS_Height", height);

            //play click sound
            if (EasyAudioUtility.instance)
                EasyAudioUtility.instance.Play(FindObjectOfType<MainMenuController>().ButtonClickSFX);
        }

        #endregion
    }
}