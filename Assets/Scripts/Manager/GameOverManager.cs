using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour 
{
	public PlayerController player; 		//Player Controller Reference
	public GameObject gameOverMenu;

	// Use this for initialization
	void Start () 
	{
		gameOverMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player.IsDead())
		{
			gameOverMenu.SetActive(true);
		}
	}
}
