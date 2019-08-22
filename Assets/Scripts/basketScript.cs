using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketScript : MonoBehaviour
{
	public static float speed=5f;
	private bool isMoving;
	private Vector3 target;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			if (isMoving==false)
			{
				isMoving = true;
				
			}

		}
		if (isMoving == true)
		{
			transform.position = Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
		}
	
	}


	
	
}