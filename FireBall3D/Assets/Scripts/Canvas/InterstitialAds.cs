using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] private string _adroidAdID = "Interstitial_Android";

    private string _adID;


    public void Awake()
    {
        _adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _adroidAdID : _adroidAdID;
        LoadAd();
    }
    public void LoadAd()
    {
        Debug.Log("Loading Ad " + _adID);
        Advertisement.Load(_adID, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing Ad " + _adID);
        Advertisement.Show(_adID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
        Debug.Log("LoadAd()");
    }
}
