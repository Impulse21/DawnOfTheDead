using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeaponFire : BaseWeaponFire 
{
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.

    void Awake ()
    {
        shootableMask = LayerMask.GetMask("Shootable");
	}

	public override void Shoot()
	{
        Vector2 fwd = transform.TransformDirection(Vector2.up);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, fwd, range, shootableMask, -1);
		
        if(hit.collider != null)
        {
        	IDamageable enemy = hit.collider.GetComponent <IDamageable> ();
            enemy.TakeDamage(damagePerShot);

            // Get collision location
            Vector2 distance = new Vector2(hit.point.x - transform.position.x, hit.point.y - transform.position.y);
            Debug.DrawRay(transform.position, fwd * distance.magnitude, Color.red, 5.0f);
        }
        else
        {
            Debug.DrawRay(transform.position, fwd * range, Color.red, 1.0f);
        }
	}
	protected override void DisableAffects()
	{
	}
}
