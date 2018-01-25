using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	public int lifeSpan = 5;

	float timer;
	// Use this for initialization
	void Awake () 
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(timer >= lifeSpan)
		{
			timer = 0;
			gameObject.SetActive(false);
		}
	}
}
