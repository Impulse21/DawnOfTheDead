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
	}

	private void processMovement()
	{
		float horizontalMov = Input.GetAxis("Horizontal");
		float verticalMov = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(horizontalMov, verticalMov, 0.0f);

		rigidBody.velocity = movement * Speed;
	}
}
