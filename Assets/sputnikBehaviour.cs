using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sputnikBehaviour : MonoBehaviour
{

	private Vector2 currPos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "bottomBorder")
		{
			Destroy(this.gameObject);

		}
		else if(col.gameObject.name == "basket" )
		{
			GameManager.Attempts -= 3;
			GameManager.Increase += 1;
			Destroy(this.gameObject);
		}
	}
}
