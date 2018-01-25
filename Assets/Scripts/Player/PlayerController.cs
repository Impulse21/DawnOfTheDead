using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAimInputType
{
    Mouse,
    Joystick
}

public class PlayerController : MonoBehaviour , IDamageable
{
    public EAimInputType aimInputType = EAimInputType.Joystick;

    [Header("Movement")]
	public float TurnRate;
	public float Speed;

    [Header("Fire")]
    public float WeaponRange = 100;

    [Header("Health")]
    public int Health = 100;

	// Private varables
	Rigidbody2D m_rigidBody;

    int currentHealth;

    bool isDead;

	// Use this for initialization
	void Awake () 
	{
		m_rigidBody = GetComponent<Rigidbody2D>();   
        currentHealth = Health; 
        isDead = false;   
	}

	// Update is called once per frame
	void Update () 
	{
        if(isDead)
        {
            return;
        }

        processAim();
    }
	
	// Update called at a fix rate
	void FixedUpdate()
	{
        if(isDead)
        {
            return;
        }

        processMovement();
    }

	protected void processMovement()
	{
		float horizontalMov = Input.GetAxis("Horizontal");
		float verticalMov = Input.GetAxis("Vertical");
        
		Vector2 movement = new Vector2(horizontalMov, verticalMov);

		m_rigidBody.velocity = movement.normalized * Speed;
	}

	protected void processAim()
	{
        switch(aimInputType)
        {
        case EAimInputType.Joystick:
            handleJoystickAim();
            break;
        default:
            handleMouseAim();
            break;
        }
	}

    protected void handleMouseAim()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        target.x += transform.position.x;
        target.y += transform.position.y;

        Vector3 vectorToTarget = target - transform.position;

        rotateToTarget(vectorToTarget);
    }

    protected void rotateToTarget(Vector3 target)
    {
        transform.LookAt(target, Vector3.forward);

        //Lock any other rotation
        Vector3 lockVector = new Vector3(0, 0, -transform.eulerAngles.z);
        transform.eulerAngles = lockVector;
    }

    private void handleJoystickAim()
    {
        float aimX = Input.GetAxis("AimX");
        float aimY = Input.GetAxis("AimY");

        Vector3 aimDir = new Vector3(aimX, aimY, 0.0f);

        if (aimDir != Vector3.zero)
        {
            transform.up = aimDir;
        }
    }

    public void TakeDamage(int damage)
    {
        if(isDead)
        {
            return;
        }

        Debug.Log("Player took damage [" + damage.ToString() + "]");
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        isDead = true;
    }
}

