using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : BaseWeaponFire 
{
	public GameObject projectile;
	public int poolSize = 20;
	public int projectileSpeed = 5;

	private ObjectPool projectilePool;
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();

		Debug.Log("Start method");
		if(projectile != null)
		{
			Debug.Log("Init Object Pool");
			projectilePool = new ObjectPool(projectile, poolSize, true);
		}
	}
	
	// Update is called once per frame

	public override void Shoot()
	{
		if(projectilePool != null)
		{
			return;
		}

		GameObject fireObj = projectilePool.getPooledObject();

		if(fireObj != null)
		{
			fireObj.transform.position = transform.position;
			fireObj.transform.rotation = transform.rotation;
			fireObj.SetActive(true);

			fireObj.GetComponent<Rigidbody2D>().velocity = fireObj.transform.up * projectileSpeed;	
		}
	}
	protected override void DisableAffects()
	{
	}
}
