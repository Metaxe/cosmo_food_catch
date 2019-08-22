using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelChangeScreen : MonoBehaviour
{
	public Text nextLevel;
	
	// Use this for initialization
	void Start () {
		int nextLvlNum = GameManager.levelCount;
		nextLevel.text = "Next level is " + nextLvlNum.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
