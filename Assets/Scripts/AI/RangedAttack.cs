using UnityEngine;

public class RangedAttack : MonoBehaviour 
{
	public GameObject projectile;			// Prefab of projectile to file
	public int numOfProjectiles;			// Number of projectiles
	public bool limitedFire;				// Limit the amount of shots to num of projectiles
	public int projectileSpeed = 5;			// Projectile Speed
	public float range = 20;				// Range to start attacking
	
	private Transform playerTransform;
	private ObjectPool m_projectilePool; 	// Object Pool for projectile

	// Use this for initialization
	void Start () 
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		m_projectilePool = new ObjectPool(projectile, 10, limitedFire);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distanceToPlayer = 
			Vector3.Distance(playerTransform.position, transform.position);
		
		if(distanceToPlayer <= range)
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		GameObject fireProjectile = m_projectilePool.getPooledObject();
		
		if(fireProjectile != null)
		{
			fireProjectile.transform.position = transform.position;
			fireProjectile.transform.rotation = transform.rotation;
			fireProjectile.SetActive(true);

			fireProjectile.GetComponent<Rigidbody2D>().velocity = 
				fireProjectile.transform.up * projectileSpeed;	
		}
	}
}
