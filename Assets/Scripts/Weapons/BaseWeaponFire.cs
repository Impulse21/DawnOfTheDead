using UnityEngine;

[System.Serializable]
public enum AmmoType
{
    Bullet,
    Fire
}

public abstract class BaseWeaponFire : MonoBehaviour 
{
    AmmoManager ammoManager;                        // Reference to the Ammo Manager
    public AmmoType ammoType;                       // Ammo type for this wepaon
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
	public float effectsDisplayTime	= 0.2f;			// The delay between effects

 	protected float timer;                          // A timer to determine when to fire.

	/** Abstract methods 		*/
	public abstract void Shoot();
	protected abstract void DisableAffects();
    uint currentAmmoCount;

	/** End Abstract methods 	*/
	// Use this for initialization
	virtual protected void Start () 
	{
        timer = 0;
    }

	// Update is called once per frame
	void Update () 
	{
        timer += Time.deltaTime;

        /*
         * We don't want to end animations while fire buttons is being pressed.
         * This is why we split up the input check and the fire button
         * 
         */
        if (Input.GetButton("Fire1"))
        {
            if (canFire())
            {
                Shoot();
                timer = 0;
            }

        }
        else
        { 
            DisableAffects();
        }

	}

    bool canFire()
    {
        return (timer >= timeBetweenBullets && Time.timeScale != 0 && HasAmmo());
    }

    bool HasAmmo()
    {
        if(ammoManager.HasAmmo(ammoType))
        {
            return true;
        }

        return (currentAmmoCount > 0);
    }
}
          