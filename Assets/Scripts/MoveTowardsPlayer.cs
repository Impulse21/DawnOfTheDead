using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour 
{
	public float rotationSpeed = 200;
	public float speed = 2;			// Players speed

	public float stopDistance = 1;

	Transform playerTransform;
	// Use this for initialization
	void Awake () 
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerTransform != null)
		{
			Vector2 target = playerTransform.position;
			Vector2 vectorToTarget = target - (Vector2)transform.position;
			/* 
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
			*/
			
			if(vectorToTarget.magnitude >= stopDistance)
			{
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, target, step);
			}
		}	
	}
}
