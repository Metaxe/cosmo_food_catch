using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Timeline;
using GoogleMobileAds.Api;


public class GameManager : MonoBehaviour
{


	public GameObject[] foodTiles;
	private float TimeLeft = 25f;
	public static int Attempts = 10;
	public static int Speed = 10;
	public static int Increase = 0;
	public Text Info;
	public Text Level;
	private bool isEnd = false;
	private bool isFailed = false;
	public static int levelCount = 1;
	private BannerView bannerView;
	//Setting up a board for spawning food.
	public int width;
	public int height;
	public GameObject tilePrefab;
	private GameObject tileToSpawn;
	public GameObject[,] spawnTiles;
	//EventSystemVariables for spawning random effects
	private float nextEventTime = 0f;
	private float EventTimer = 0f;
	public GameObject[] animals;
	public GameObject[] meteorite;
	public GameObject sputnik;
	public GameObject axe;
	
 	
	
	void Start()
	{
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
		TimeLeft += levelCount*5;
		float spawnSpeed = 1.0f-levelCount/10;
		InvokeRepeating("StartGame", spawnSpeed, spawnSpeed);
		SetupNET();
	}


	private void Update()
	{
		TimeLeft -= Time.deltaTime;
		if (TimeLeft > 0)
		{
			Info.text = Attempts.ToString();
			Level.text = levelCount.ToString();
			if (Attempts == 0)
			{
				isFailed = true;
				endGame();
			}
		}
		else
		{
			endGame();
		}
		//EventSystem
		//Creating dungerous obstacles
		EventTimer -= Time.deltaTime;
		if (TimeLeft == 0)
		{
			CreateRandomEvent();
		}
	}
	
	private void Setup()
	{
		for (int i = 0; i < height; i++){
			for (int y = 0; y < width; y++)
			{
				Vector2 tempPosition = new Vector2(i,y);
				GameObject backgroundTile = Instantiate(tilePrefab, tempPosition,Quaternion.identity) as GameObject;
				backgroundTile.transform.parent = this.transform;
				backgroundTile.name = "("+i+","+y+")";
				spawnTiles[i, y] = backgroundTile;
			}
		}
		
	}
	
	public void StartGame()
	{
		float coordinateX = Random.Range(-2.0f, 2.0f);
		float coordinateY = -8f;
		/*if (SceneManager.GetActiveScene().buildIndex == 1||SceneManager.GetActiveScene().buildIndex == 3)
		{
			 coordinateY = 8f;
		}
		else
		{
			coordinateY = -8f;
		}*/
		
		int tileSet = Random.Range(0, 10);
		Vector2 tempPosition = new Vector2(coordinateX, coordinateY);
		int tileToUse = Random.Range(0, foodTiles.Length);
		GameObject foodTile = Instantiate(foodTiles[tileToUse], tempPosition, Quaternion.identity);
		foodTile.transform.parent = this.transform;
		foodTile.name = this.gameObject.name;
	}
	

	public void endGame()
	{
		if (isFailed == true)
		{
			Attempts = 10;
			isFailed = false;
			SceneManager.LoadScene(0);
		}
		else
		{
			Attempts = 10;
			levelCount += 1;
			SceneManager.LoadScene(2);
		}
		
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

	private void SetupNET()
	{
		nextEventTime = Random.Range(0,1) + Random.Range(0,100)/100;
	}

	private void CreateRandomEvent()
	{
		int randomEvent = Random.Range(0, 100);
		if(0<=randomEvent|randomEvent<=33)
		{
			float coordinateX = Random.Range(-2.0f, 2.0f);
			float coordinateY = -8f;
			Vector2 tempPosition = new Vector2(coordinateX, coordinateY);
			int tileToUse = Random.Range(0, animals.Length);
			GameObject foodTile = Instantiate(animals[tileToUse], tempPosition, Quaternion.identity);
			foodTile.transform.parent = this.transform;
			foodTile.name = this.gameObject.name;
				
		}
		else if(34<=randomEvent|randomEvent<=50)
		{
			float coordinateX;
			if (Random.Range(0, 10) > 5)
			{
				coordinateX = -4.0f;
			}
			else
			{
				coordinateX = 4.0f;
			}
			
			float coordinateY = Random.Range(0f, 3.6f);
			Vector2 tempPosition = new Vector2(coordinateX,coordinateY);
			Instantiate(sputnik,tempPosition, Quaternion.identity);
		}
		else if(51<=randomEvent|randomEvent<=66){
				
		}
		else {
				
		}
	}
  	

}

