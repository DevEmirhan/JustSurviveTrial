using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MainPanel
{
    [Header("Bindings")]
    [SerializeField] private GameCoordinator gameCoordinator;

    [Header("KEYS")]
    [SerializeField] private List<GameObject> Keys = new List<GameObject>();
    [SerializeField] private List<Image> KeyImages = new List<Image>();

    [Header("Countdown")]
    [SerializeField] private Text countdownText;

    private bool isActiveForCountdown = false;
    private bool colorChanged = false;
    private int keyRequirementForThisLevel = 3;
    private int currentKeyCount = 0;
    private float levelTimeLimit = 30f;

  

    public override void Refresh()
    {
        levelTimeLimit = gameCoordinator.CurrentLevel.levelTimeLimit;
        keyRequirementForThisLevel = gameCoordinator.CurrentLevel.keyRequirement;
        currentKeyCount = 0;
        ActivateKeySlots(keyRequirementForThisLevel);
        CloseAllKeyUI();
        countdownText.color = Color.white;
        isActiveForCountdown = true;
    }

    private void Update()
    {
        if(GameManager.Instance.CurrentState == GameManager.GameState.Gameplay && isActiveForCountdown)
        {
            levelTimeLimit -= Time.deltaTime;
            int seconds = (int)(levelTimeLimit % 60);
            int munites = (int)(levelTimeLimit / 60) % 60;
            string timerString = string.Format("{0:00}:{1:00}", munites, seconds);
            countdownText.text = timerString;
            if (levelTimeLimit >0 && levelTimeLimit <=10 && !colorChanged)
            {
                countdownText.color = Color.red;
                colorChanged = true;
            } else if ( levelTimeLimit <= 0)
            {
                levelTimeLimit = 0f;
                countdownText.text = "OVER";
                gameCoordinator.DecideOnTimesUp();
                isActiveForCountdown = false;
            } 

        }
    }

    public void ActivateKeySlots(int requirement)
    {
        foreach(var key in Keys)
        {
            key.SetActive(false);
        }
        for (int i = 0; i < keyRequirementForThisLevel; i++)
        {
            Keys[i].SetActive(true);
        }
    }
    public void CloseAllKeyUI()
    {
        foreach(var keyImg in KeyImages)
        {
            keyImg.enabled = false;
        }
    }
    public void FoundKey()
    {
        currentKeyCount++;
        KeyImages[currentKeyCount - 1].enabled = true;
    }

}
