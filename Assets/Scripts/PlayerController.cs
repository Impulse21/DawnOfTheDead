using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[Header("Movement")]
	public float TurnRate;
	public float Speed;

	// Private varables
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	// Update called at a fix rate
	void FixedUpdate()
	{
		processMovement();
		processRotation();
	}

	protected void processMovement()
	{
		float horizontalMov = Input.GetAxis("Horizontal");
		float verticalMov = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(horizontalMov, verticalMov);

		rigidBody.velocity = movement.normalized * Speed;
	}

	protected void processRotation()
	{
		float aimX = Input.GetAxis("AimX");
		float aimY = Input.GetAxis("AimY");

		Vector3 target = new Vector3(aimX, aimY, 0.0f);
		Debug.Log("Target location (" + target.x + ", " + target.y + ")");

		Vector3 vectorToTarget = (target - transform.position).normalized;
		Debug.Log("Vector to target (" + vectorToTarget.x + ", " + vectorToTarget.y +")");

		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Debug.Log("Angle is " + angle);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}

