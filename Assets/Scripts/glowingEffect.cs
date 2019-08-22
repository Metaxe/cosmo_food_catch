using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class glowingEffect : MonoBehaviour
{
	private bool isFaded = true;
	private SpriteRenderer rend;
	// Use this for initialization
	void Start ()
	{
		rend = GetComponent<SpriteRenderer>();
		Color c = rend.material.color;
		c.a = 0f;
		rend.material.color = c;
		
	}
	
	void FixedUpdate () {
		if (isFaded == true)
		{
			StartFadingIn();
		}
		else
		{
			StartFadingOut();
		}
	}

	IEnumerator FadeIn()
	{
		for (float f = 0.05f; f <= 0.75f; f += 0.05f)
		{
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(0.3f);
		}

		isFaded = false;
	}

	public void StartFadingIn()
	{
		StartCoroutine(FadeIn());
	}
	// Update is called once per frame

	
	IEnumerator FadeOut()
	{
		for (float f = 0.75f; f >= -0.05f; f -= 0.05f)
		{
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(0.3f);
		}
		GetNewPostion();
		isFaded = true;
		
	}

	public void StartFadingOut()
	{
		StartCoroutine(FadeOut());
	}

	public void GetNewPostion()
	{
		
		this.transform.position = new Vector3(Random.Range(-8.18f, 8.17f),Random.Range(-0.86f, 0.81f));
	}
}
