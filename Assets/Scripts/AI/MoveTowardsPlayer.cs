using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour 
{
	public float rotationSpeed = 200;
	public float speed = 2;			// Players speed

	public float stopDistance = 1;

	Animator m_animator;

	Transform playerTransform;
	// Use this for initialization
	void Awake () 
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerTransform != null)
		{
			Vector2 target = playerTransform.position;
			Vector2 vectorToTarget = target - (Vector2)transform.position;

			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			// Not sure why I need to add a rotation adjustment to the rotation.
			Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
		
			if(vectorToTarget.magnitude >= stopDistance)
			{
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, target, step);
				m_animator.SetBool("IsWalking", true);
			}
			else
			{
				m_animator.SetBool("IsWalking", false);
			}
		}	
	}

	// TODO Determine if this is required
	private bool IsAttacking()
	{
		return true;
	}
}
