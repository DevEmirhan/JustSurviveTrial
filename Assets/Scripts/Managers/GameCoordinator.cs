using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    LevelProfiler levels;

    private Level currentLevel;
    public Level CurrentLevel { get {return currentLevel; } }

    public void Awake()
    {
        Application.targetFrameRate = 60;
    }
    public void Initialize()
    {
        //playerController.Initialize();
    }

    public void Reload()
    {
        LoadLevel(SaveManager.Instance.CurrentSave.CurrentLevel);
        playerController.SetPlayerPosition(currentLevel.playerStartPos.position);
        PoolManager.Instance.DismissPools();
        //playerController.Reload();
    }

    private void destroyLastLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
            currentLevel = null;
        }
    }

    public void LoadLevel(int levelID)
    {
        if (currentLevel != null)
        {
            destroyLastLevel();
        }
        if (levelID > levels.AllsLevels.Count - 1)
        {
            SaveManager.Instance.CurrentSave.CurrentLevel = Random.Range(0, levels.AllsLevels.Count);
            levelID = SaveManager.Instance.CurrentSave.CurrentLevel;
            SaveManager.Instance.Save();
        }
        currentLevel = Instantiate(levels[levelID]);
        currentLevel.transform.position = Vector3.zero;
        currentLevel.gameObject.SetActive(true);
        


    }

    public void StartGame()
    {
        playerController.StartGame();
        LoadLevel(SaveManager.Instance.CurrentSave.CurrentLevel);
        //prog.ProgressBarReset();

    }

    public void GameOver()
    {
        //playerController.GameOver();
        Reload();

    }
    public void WinGame()
    {
        //playerController.WinGame();
        SaveManager.Instance.CurrentSave.CurrentLevel++;
        SaveManager.Instance.Save();
        //PlayerPrefs.SetInt("levelIndex", PlayerPrefs.GetInt("levelIndex") + 1);
        //PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") + PlayerController.Instance.collectedCoinCount);
        Reload();

    }
}
