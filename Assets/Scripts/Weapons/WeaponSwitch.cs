using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
	public uint selectedWeapon = 0;

	
	protected AmmoManager ammoManager;
	// Use this for initialization
	void Start () 
	{
		ammoManager = AmmoManager.sharedInstance;

		if(ammoManager == null)
		{
			Debug.LogWarning("Ammo Manager is null");
		}

		SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedWeapon = 0;
			SelectWeapon();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			selectedWeapon = 1;
			SelectWeapon();
		}
	}

	void SelectWeapon()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			if(i == selectedWeapon)
			{
				transform.GetChild(i).gameObject.SetActive(true);
				BaseWeaponFire weaponFire = transform.GetChild(i).gameObject.GetComponentInChildren<BaseWeaponFire>();

				if(weaponFire != null)
				{
					//AmmoManager.sharedInstance.SetSelected(weaponFire.ammoType);
				}
				else
				{
					Debug.LogWarning("Unable to retireve BaseWeaponFire from gameobject " + transform.GetChild(i).gameObject.name);
				}
			}
			else
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}
