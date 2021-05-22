using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MainPanel
{
    [Header("UPDATE FIELDS")]
    public Text levelText;
    //public Text coinText;

    public override void Refresh()
    {
        levelText.text = "LEVEL " + (SaveManager.Instance.CurrentSave.CurrentLevel+1);
        //coinText.text = "Coin " + SaveManager.Instance.CurrentSave.CoinAmount;
    }
}
