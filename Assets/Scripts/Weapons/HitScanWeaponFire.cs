using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeaponFire : BaseWeaponFire 
{
	
    Ray shootRay = new Ray();                       // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
	LineRenderer gunLine;                           // Reference to the line renderer.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.

    void Awake ()
    {
		gunLine = GetComponent<LineRenderer>();
	}

	public override void Shoot()
	{
		shootableMask = LayerMask.GetMask("Shootable");

 		shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
        	//EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition (1, shootHit.point);
        }
    	else	// If the raycast didn't hit anything on the shootable layer...
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
	}
	protected override void DisableAffects()
	{
		gunLine.enabled = false;
	}
}
