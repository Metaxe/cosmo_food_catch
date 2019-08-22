using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalCollision : MonoBehaviour {
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "bottomBorder")
		{
			Destroy(this.gameObject);

		}
		else if(col.gameObject.name == "basket" )
		{
			GameManager.Attempts += 2;
			GameManager.Increase += 1;
			Destroy(this.gameObject);
		}
	}
}
