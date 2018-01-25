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

    Animator m_animator;

	/** End Abstract methods 	*/
	// Use this for initialization
	virtual protected void Start () 
	{
		m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            // ... shoot the gun.
			if (m_animator != null)
				m_animator.SetTrigger("Fire");
				
            Shoot ();
			timer = 0;
        }

		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			//DisableAffects();
		}
	}
}
          