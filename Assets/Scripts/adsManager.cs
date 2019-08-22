using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class adsManager : MonoBehaviour {
	
	private BannerView bannerView;

	
	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		string appId = "ca-app-pub-6758883431877672~2155561065";
		#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
            string appId = "unexpected_platform";
        #endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);
		this.RequestBanner();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void RequestBanner()
	{
		#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder().Build();
		bannerView.LoadAd(request);
	}
	
}
