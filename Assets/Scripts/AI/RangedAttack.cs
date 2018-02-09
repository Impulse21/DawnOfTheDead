using UnityEngine;

public class RangedAttack : MonoBehaviour 
{
	public GameObject projectile;				// Prefab of projectile to file
	public int numOfProjectiles;				// Number of projectiles
	public bool limitedFire;					// Limit the amount of shots to num of projectiles
	public int projectileSpeed = 5;				// Projectile Speed
	public float range = 20;					// Range to start attacking
	public float fireRate = 2.0f;

	protected float timer;

	private Animator m_animator;
	private Transform m_playerTransform;
	private ObjectPool m_projectilePool; 		// Object Pool for projectile
	private MoveTowardsPlayer m_movementComp;	// Reference to movement component

	// Use this for initialization
	void Start () 
	{
		timer = 0;
		m_playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		m_projectilePool = new ObjectPool(projectile, 10, limitedFire);
		
		m_movementComp = GetComponent<MoveTowardsPlayer>();
		m_animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distanceToPlayer = 
			Vector3.Distance(m_playerTransform.position, transform.position);

		if(distanceToPlayer <= range)
		{
			Debug.Log("Player is in range " + distanceToPlayer);
			timer += Time.deltaTime;

			if(timer >= fireRate)
			{
				signalStopMovement();
				Shoot();
				
				timer = 0;
			}
		}
		else
		{
			Debug.Log("Player is not in range " + distanceToPlayer);
			singalStartMovement();
			timer = 0;
		}
	}

	private void Shoot()
	{
		m_animator.SetBool("IsAttacking", true);
		GameObject fireProjectile = m_projectilePool.getPooledObject();
		
		if(fireProjectile != null)
		{
			fireProjectile.transform.position = transform.position;
			fireProjectile.transform.rotation = transform.rotation;
			fireProjectile.SetActive(true);

			fireProjectile.GetComponent<Rigidbody2D>().velocity = 
				fireProjectile.transform.up * projectileSpeed;	
		}
		m_animator.SetBool("IsAttacking", false);
	}

	private void signalStopMovement()
	{
		if(m_movementComp != null)
		{
			m_movementComp.enableWalk = false;
		}
	}

	private void singalStartMovement()
	{
		if(m_movementComp != null)
		{
			m_movementComp.enableWalk = true;
		}
	}
}
