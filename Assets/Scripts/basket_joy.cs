using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class basket_joy : MonoBehaviour
{
	private Rigidbody2D myBody;

	private float basketSpeed = 3f;
	
	// Use this for initialization
	void Start ()
	{
		myBody = this.GetComponent<Rigidbody2D>();
	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical"));
		transform.Translate(moveVec*basketSpeed*Time.deltaTime);
	}
}
