using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public bool isSurvival;
    Data data;
    string str;

    public float volume;

    int lastLevelIndex;
    int[] scores;
    public int survivalScore;

    private void Awake()
    {
        isSurvival = false;
        data = new Data();
        DontDestroyOnLoad(this.gameObject);
        LoadData();

        scores = data.scores;
        lastLevelIndex = data.lastLevelIndex;
        survivalScore = data.survivalScore;
    }


    public int getLevelScore(int index)
    { return scores[index]; }
    public int getLastLevelIndex()
    { return lastLevelIndex; }
    public void changeLastLevelIndex(int num)
    {
        lastLevelIndex = num;
        SaveData();
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("settings"))
        {
            str = PlayerPrefs.GetString("settings");
            data = JsonUtility.FromJson<Data>(str);
        }
        else
        {
            //data.lastLevelIndex = 0;
            data.scores = new int[] { 0, 0, 0, 0, 0, 0 };
            survivalScore = 0;
        }
    }

    public void SetScore(int score)
    {

        scores[lastLevelIndex] = score;
    }

    public void SaveData()
    {
        data.lastLevelIndex = lastLevelIndex;
        data.scores = scores;
        data.survivalScore = survivalScore;

        str = JsonUtility.ToJson(data);

        PlayerPrefs.SetString("settings", str);
        PlayerPrefs.Save();
    }

}
