using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinPanel : MainPanel
{
    [Header("Bindings")]
    [SerializeField] private GameCoordinator gameCoordinator;
    [Header("UPDATE FIELDS")]
    public Text levelText;
    public Text coinText;

    public override void Refresh()
    {
        levelText.text = "LEVEL " + (SaveManager.Instance.CurrentSave.CurrentLevel);
        coinText.text = "+" + gameCoordinator.CurrentLevel.coinValue;
    }
}
