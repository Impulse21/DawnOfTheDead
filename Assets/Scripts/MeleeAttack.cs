using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : BaseAttack 
{
	void OnTriggerEnter2D(Collider2D coll) 
	{
    	if (coll.gameObject.tag == "Player")
		{
			m_animator.SetBool("IsAttacking", true);
			Debug.Log("Tigger entered");
            coll.gameObject.SendMessage("TakeDamage", attackDamage);
		}  
    }


	void OnTriggerExit2D(Collider2D coll) 
	{
    	if (coll.gameObject.tag == "Player")
		{
			m_animator.SetBool("IsAttacking", false);
			Debug.Log("Tigger Exit");
            coll.gameObject.SendMessage("TakeDamage", attackDamage);
		}  
    }	
}
