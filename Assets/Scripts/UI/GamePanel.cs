using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MainPanel
{
    [Header("UPDATE FIELDS")]
    public Text levelText;
    public Text nextLevelText;
    public Text coinText;

    private int coinsForThisLevel;
    public int CoinsForThisLevel { get { return CoinsForThisLevel; } }

    [SerializeField]
    private Slider progressBar;
    [HideInInspector]
    public float coinMultiplier = 1f;

    [SerializeField]
    private GameCoordinator gameCo;

    private static  GamePanel instance;

    public static GamePanel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GamePanel>();
            }

            return instance;
        }
    }
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as GamePanel;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    public override void Refresh()
    {
        //levelText.text = "" + (SaveManager.Instance.CurrentSave.CurrentLevel+1);
        //nextLevelText.text = "" + (SaveManager.Instance.CurrentSave.CurrentLevel + 2);
        //coinText.text = "" + SaveManager.Instance.CurrentSave.CoinAmount;
        //progressBar.value = 0f;
        //coinsForThisLevel = 0;
    }

    public void IncreaseCoin(int coinAmount)
    {
        //coinsForThisLevel += coinAmount;
        //coinText.text = "" + (SaveManager.Instance.CurrentSave.CoinAmount + coinsForThisLevel);
    }

    //public void DeadEnemy()
    //{
    //    progressBar.value = gameCo.currentLevel.GetRatio();
    //}

    public int CalculateGameFinalMult()
    {
        //if(progressBar.value < 0.6f)
        //{
        //    coinMultiplier = 1f;
        //} else if( progressBar.value >= 0.6f && progressBar.value < 0.85f)
        //{
        //    coinMultiplier = 1.5f;
        //}
        //else if (progressBar.value >= 0.85f)
        //{
        //    coinMultiplier = 2f;
        //}
        int finalM = (int)(coinMultiplier * coinsForThisLevel);
        return finalM;

    }




}
