using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour 
{
	public float attackDamage = 0;			// Attack damage

	protected Animator m_animator;
	// Use this for initialization
	protected virtual void Awake () 
	{
		m_animator = GetComponent<Animator>();
	}
}
