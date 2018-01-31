using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : BaseAttack 
{
	public float damageRate = 0.5f;

	protected float timer;                          // A timer to determine when to fire.

	bool playerInRange;
	IDamageable playerDmg;

	protected override void Awake()
	{
		base.Awake();
        playerDmg = GameObject.FindGameObjectWithTag ("Player").GetComponent<IDamageable>();
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
                playerDmg.TakeDamage((int)attackDamage);

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
    	if (coll.gameObject.tag == "Player")
		{
			playerInRange = true;
			m_animator.SetBool("IsAttacking", true);
		}  
    }


	void OnTriggerExit2D(Collider2D coll) 
	{
    	if (coll.gameObject.tag == "Player")
		{
			playerInRange = false;
			m_animator.SetBool("IsAttacking", false);
		}  
    }	
}
