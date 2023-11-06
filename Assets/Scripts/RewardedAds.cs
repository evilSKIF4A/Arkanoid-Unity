using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Button buttonAds;
    [SerializeField] private GameObject platform;

    private string rewardedVideo = "Rewarded_Android";

    private void Awake()
    {
        buttonAds.interactable = false;
    }
    private void Start()
    {
        LoadAds();
    }
    public void LoadAds()
    {
        Advertisement.Load(rewardedVideo, this);
    }
    public void ShowAds()
    {
        buttonAds.interactable = false;
        Advertisement.Show(rewardedVideo, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Rewarded Ads Load");
        if (placementId.Equals(rewardedVideo))
        {
            buttonAds.onClick.AddListener(ShowAds);
            buttonAds.interactable = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Rewarded Ads Load Failed");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(placementId.Equals(rewardedVideo) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            platform.SendMessage("GiveLife");
        }
    }
}
