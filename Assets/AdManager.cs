using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    public Button init;
    public Text initTxt;
    public InterstitialAd interstitial;
    public Text interText;
    public RewardedAd rewarded;
    public Text rewText;
    public Text rewards;
    private int amount = 0;

    public void initAdMob()
    {
        MobileAds.Initialize(initStatus => { });
        init.interactable = false;
        initTxt.text = "AdMob initialized";
    }

    public void loadInter()
    {
        #if UNITY_ANDROID
            string interAdUnitId = "ca-app-pub-3940256099942544/1033173712";
        #else
            string interAdUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interAdUnitId);
        // Create an empty ad request.
        AdRequest requestInter = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(requestInter);
        interText.text = "Interstitial ad loaded";
    }

    public void showInter() {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            interText.text = "Load interstitial ad";
        }
    }

    public void loadReward()
    {
        #if UNITY_ANDROID
            string rewardAdUnitId = "ca-app-pub-3940256099942544/5224354917";
        #else
            string rewardAdUnitId = "unexpected_platform";
        #endif

        // Initialize a RewardedAd.
        this.rewarded = new RewardedAd(rewardAdUnitId);
        // Create an empty ad request.
        AdRequest requestReward = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.rewarded.LoadAd(requestReward);
        rewText.text = "Rewarded ad loaded";
    }

    public void showReward()
    {
        if (this.rewarded.IsLoaded())
        {
            this.rewarded.Show();
            rewText.text = "Load rewarded ad";
        }
        this.rewarded.OnUserEarnedReward += HandleUserEarnedReward;
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        this.amount++; 
        this.rewards.text = "Rewarded ads watched: "
                        + amount.ToString();
    }
}
