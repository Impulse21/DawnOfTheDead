using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[Header("Movement")]
	public float TurnRate;
	public float Speed;

	[Header("Movement Debug")]
	public GameObject targetRotation;

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
		if(targetRotation == null)
		{
			return;
		}

		float aimX = Input.GetAxis("AimX");
		float aimY = Input.GetAxis("AimY");

		//Vector3 target = new Vector3(aimX, aimY, 0.0f);
		Vector3 target = targetRotation.transform.position;
		Debug.Log("Target location (" + target.x + ", " + target.y + ")");

		Vector3 vectorToTarget = target - transform.position;
		Debug.Log("Vector to target (" + vectorToTarget.x + ", " + vectorToTarget.y +")");

		Quaternion rot = Quaternion.LookRotation(transform.position - target, Vector3.forward);
		transform.rotation = rot;

		/* Here we are limiting rotation to only the Z Axis 				*/
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		rigidBody.angularVelocity = 0;
	}
}

