using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
	
	public int health = 100; 	// Starting health

	int m_currentHealth;
	bool isDead = false;
	

	// Use this for initialization
	void Start () 
	{
		
	}

	void Awake()
	{
		m_currentHealth = health;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	public void TakeDamage(int dmg)
	{
		if(isDead)
		{
			return;
		}

		// TODO DMG auto
		m_currentHealth -= dmg;
		Debug.Log("Enemy " + gameObject.name + " took Dmg [" + m_currentHealth.ToString() + "]");

		if(m_currentHealth <= 0)
		{
			Death();
		}
	}

	void Death()
	{
		isDead = true;
		gameObject.SetActive(false);

		Debug.Log("Enemy is Dead");   
		// TODO Set Collider to trigger
		// Play Death Audio
		// Expolode
	}
}
