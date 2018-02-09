using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // Potential items
    public List<GameObject> items = new List<GameObject>();
    public float dropPercentage = 20;

    public void DropItem()
    {
        if (CanDrop())
        {
            int index = Random.Range(0, items.Count - 1);

            Debug.Log("Droping item");
            Instantiate(items[index], transform.position, Quaternion.identity);
        }
    }

    /** Only drop the item if it fits within the propbablilty range */
    private bool CanDrop()
    {
        return Random.Range(1, 101) <= dropPercentage;
    }
}
