using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Api;

public class initAdMobs : MonoBehaviour
{
    public Button init;
    public Text txt;

    public void ButtonClicked()
    {
        MobileAds.Initialize(initStatus => { });
        init.interactable = false;
        txt.text = "AdMob initialized";
    }
}
