using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : BaseAttack 
{
	public int damageRate = 2;

	protected float timer;                          // A timer to determine when to fire.

	bool playerInRange;
	GameObject player;

	protected override void Awake()
	{
		base.Awake();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInRange = false;
		timer = 0;
	}

	void Update()
	{
		if(playerInRange)
		{
				
			timer += Time.deltaTime;

			if(timer >= damageRate)
			{
			
				player.SendMessage("TakeDamage", attackDamage);
				timer = 0;
			}
		}
		else
		{
			timer = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
    	if (coll.gameObject == player)
		{
			playerInRange = true;
			m_animator.SetBool("IsAttacking", true);
			Debug.Log("Tigger entered setting player in range");
		}  
    }


	void OnTriggerExit2D(Collider2D coll) 
	{
    	if (coll.gameObject == player)
		{
			playerInRange = false;
			m_animator.SetBool("IsAttacking", false);
			Debug.Log("Tigger Exit");
		}  
    }	
}
