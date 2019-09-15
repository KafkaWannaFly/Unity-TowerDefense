using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public Button[] levelButton;
    static public string reachedLevelKeyword = "reachedLevel";

    private void Start()
    {
        this.showEnableLevel();
    }

    void showEnableLevel()
    {
        int reachedLevel = PlayerPrefs.GetInt(reachedLevelKeyword, 1);
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > reachedLevel)
            {
                levelButton[i].interactable = false;
            }
        }
    }

    public void resetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
