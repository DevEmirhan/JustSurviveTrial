using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAddImplementation : MonoBehaviour,IUnityAdsListener
{
    [SerializeField] private RewardPopup rewardPopup;
    //You need to import your app ID as string for Ads;
    string GooglePlay_ID = "4140843";
    //If you are at the development phase, you should use Monetizaion on test mode.
    bool testMode = true;
    //This string should be exact the same as ID string which you determined on Dashboard.
    string myPlacementId = "rewardVideo";

    void Start()
    {
        //Activating listener and Initialize it with our data
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, testMode);
    }
    //This is for quick, transitions ads which can be skipped by user.
    public void DisplayInterstitialAD()
    {
        Advertisement.Show();
    }
    //This is a reward ad function and you should attach it on a button in the screen.
    public void DisplayVideoAd()
    {
        Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }
    //As one of the features of IUnityAdsListener; you can detect the user behavior as finished, skipped or failed. 
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
            //Sorry but failed
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
