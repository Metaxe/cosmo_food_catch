using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class joystick_sm : MonoBehaviour
{
	public Transform Player;

	public float speed = 4.0f;

	private bool TouchStart = false;
	private Vector2 pointA;
	private Vector2 pointB;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			pointA =Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.transform.position.z));
		}

		if (Input.GetMouseButton(0))
		{
			TouchStart = true;
			pointB =Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.transform.position.z));
			
		}
		else
		{
			TouchStart = false;
		}
	}


	private void FixedUpdate()
	{
		if (TouchStart)
		{
			Vector2 offset = pointB - pointA;
			Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
			moveCharacter(direction);
		}
}


	void moveCharacter(Vector2 direction)
	{
		Player.Translate(direction * speed * Time.deltaTime);
	}
}
