using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AmmoInfo
{
    public AmmoType type;
    public bool unlimited;
    public uint max;
    public uint currentCount;
}

public class AmmoManager : MonoBehaviour
{
    public List<AmmoInfo> ammoInfo;

    Dictionary<AmmoType, AmmoInfo>  ammoData;

    private void Start()
    {
        foreach (AmmoInfo info in ammoInfo)
        {
            try
            {
                ammoData.Add(info.type, info);
            }
            catch(ArgumentException e)
            {
                Debug.LogWarning("This item type already exists " + info.type);
            }
        }

    }

    public bool HasAmmo(AmmoType ammoType)
    {
        AmmoInfo value;
        if(ammoData.TryGetValue(ammoType, out value))
        {
            return (value.currentCount < 0 || value.unlimited);
        }
        else
        {
            return false;
        }
        
    }

    public void AmmoUsed(AmmoType ammoType)
    {
        AmmoInfo value;
        if(ammoData.TryGetValue(ammoType, out value))
        {
            if(value.unlimited)
            {
                return;
            }
            else
            {
                value.currentCount--;
            }
        }
    }

    public void OnAmmoPickup(AmmoPickup ammoPickup)
    {
        AmmoInfo value;
        if (ammoData.TryGetValue(ammoPickup.type, out value))
        {
            Debug.Log("Ammo has increaed for " + ammoPickup.type);
            value.currentCount = (uint)Mathf.Clamp(ammoPickup.count, 0, value.max);
        }
        else
        {
            Debug.LogWarning("Item Type does not exists in the manager [" + ammoPickup.type.ToString() + "]");
        }

    }
}
