using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct AmmoInfo
{
    public AmmoType type;
    public Sprite UiSprite;
    public bool unlimited;
    public uint max;
    public uint currentCount;
}

public class AmmoManager : MonoBehaviour
{
    //public static AmmoManager sharedInstance;

    public Text ammoText;
    public Image ammoImage;

    public List<AmmoInfo> ammoInfo;

    AmmoInfo activeAmmo;

    Dictionary<AmmoType, AmmoInfo>  ammoData = new Dictionary<AmmoType, AmmoInfo>();

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

    public void SetSelected(AmmoType ammoType)
    {
        if (ammoData.TryGetValue(ammoType, out activeAmmo))
        {
            updateUIInfo(activeAmmo);
        }
        else
        {
            Debug.LogWarning("Item Type does not exists in the manager [" + ammoType.ToString() + "]");
        }
    }

    public bool HasAmmo(AmmoType ammoType)
    {
        AmmoInfo value;
        if(ammoData.TryGetValue(ammoType, out value))
        {
            return (value.unlimited || value.currentCount > 0);
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
                ammoData[ammoType] = value;
                updateUiAmmoAmmount(ammoData[ammoType]);
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
            ammoData[ammoPickup.type] = value;

            if(activeAmmo.type == ammoPickup.type)
            {
                updateUiAmmoAmmount(value);
            }
        }
        else
        {
            Debug.LogWarning("Item Type does not exists in the manager [" + ammoPickup.type.ToString() + "]");
        }
    }

    public void updateUIInfo(AmmoInfo ammoInfo)
    {
        updateUiAmmoAmmount(ammoInfo);

        if (ammoImage != null)
        {
            ammoImage.sprite = ammoInfo.UiSprite;
        }
    }

    private void updateUiAmmoAmmount(AmmoInfo ammoInfo)
    {
        if (ammoText != null)
        {
            ammoText.text = (ammoInfo.unlimited) ? "--" : ammoInfo.currentCount.ToString() + "/" + ammoInfo.max.ToString();
        }
    }
}
