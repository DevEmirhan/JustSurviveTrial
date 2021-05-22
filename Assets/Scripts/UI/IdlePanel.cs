using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IdlePanel : MainPanel
{
    [Header("UPDATE FIELDS")]
    public Text levelText;
    public Text coinText;

    public override void Refresh()
    {
        levelText.text = "LEVEL " + (SaveManager.Instance.CurrentSave.CurrentLevel+1);
        coinText.text = "" + SaveManager.Instance.CurrentSave.CoinAmount;
    }
}
