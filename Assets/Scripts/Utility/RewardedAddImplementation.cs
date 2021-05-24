using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAddImplementation : MonoBehaviour,IUnityAdsListener
{
    [SerializeField] private RewardPopup rewardPopup;
    string GooglePlay_ID = "4140843";
    bool testMode = true;

    string myPlacementId = "rewardVideo";

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, testMode);
    }
    public void DisplayInterstitialarAD()
    {
        Advertisement.Show();
    }
    public void DisplayVideoAd()
    {
        Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            rewardPopup.Show(true);
            SaveManager.Instance.CurrentSave.CoinAmount += 50;
            SaveManager.Instance.Save();
            UIManager.Instance.RefreshPanel(0);
        }
        else if (showResult == ShowResult.Failed)
        {
            rewardPopup.Show(false);
            //Sorry
        }
        else return;
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

}
