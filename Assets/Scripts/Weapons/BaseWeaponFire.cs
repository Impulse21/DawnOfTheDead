using UnityEngine;

public abstract class BaseWeaponFire : MonoBehaviour 
{
	public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
	public float effectsDisplayTime	= 0.2f;			// The delay between effects
 	protected float timer;                          // A timer to determine when to fire.

	/** Abstract methods 		*/
	public abstract void Shoot();
	protected abstract void DisableAffects();

	/** End Abstract methods 	*/
	// Use this for initialization
	virtual protected void Start () 
	{
        timer = timeBetweenBullets;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if(Input.GetButton("Fire1"))
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                Shoot();
                timer = 0;
            }
            
        }
        else
        {
            timer = timeBetweenBullets;
            DisableAffects();
        }

	}
}
          