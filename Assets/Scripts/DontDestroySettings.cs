using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySettings : MonoBehaviour
{
    int lastLevelIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int getLastLevelIndex()
    { return lastLevelIndex; }
    public  void changeLastLevelIndex(int num)
    {
        lastLevelIndex = num;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
