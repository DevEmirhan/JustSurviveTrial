using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public bool testMode;
    public Level[] Levels;
    public Level currentLevel;
    public int currentLevelIndex;
    public int randomStart;

    public void Initialize()
    {
        if (!PlayerPrefs.HasKey("randomLevel"))
        {
            PlayerPrefs.SetInt("randomLevel", -1);
        }
        if (!PlayerPrefs.HasKey("levelIndex"))
        {
            PlayerPrefs.SetInt("levelIndex", 0);
            currentLevelIndex = 0;
            currentLevel = Levels[0];
            Save currentSave = SaveManager.Instance.Load();
            currentSave.CurrentLevel = 0;
            SaveManager.Instance.Save();
        }
    }
    public void LoadScene()
    {
        if (testMode)
        {
            currentLevel = Levels[currentLevelIndex];
        }
        else
        {

            //currentLevelIndex = PlayerPrefs.GetInt("levelIndex");
            currentLevelIndex = SaveManager.Instance.CurrentSave.CurrentLevel;
            if (currentLevelIndex > Levels.Length - 1)
            {
                if (currentLevelIndex + 1 % 6 == 0)
                {
                    currentLevel = Levels[5];
                }
                else
                {
                    if (PlayerPrefs.GetInt("randomLevel") == -1)
                    {
                        int randomIndex = Random.Range(randomStart, Levels.Length);
                        while ((randomIndex + 1) % 6 == 0)
                        {
                            randomIndex = Random.Range(randomStart, Levels.Length);
                        }
                        PlayerPrefs.SetInt("randomLevel", randomIndex);
                        currentLevel = Levels[randomIndex];
                    }
                    else
                    {
                        int randomIndex = PlayerPrefs.GetInt("randomLevel");
                        currentLevel = Levels[randomIndex];
                    }

                }

            }
            else
            {
                currentLevel = Levels[currentLevelIndex];
            }

        }
    }

}
