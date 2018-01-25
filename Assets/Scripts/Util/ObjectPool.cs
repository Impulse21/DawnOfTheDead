using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
	public bool CanGrow {get; set;}

	private GameObject pooledObject;

	List<GameObject> m_pooledObjects;

	public ObjectPool(GameObject objectToPool, int size)
	{ 
		CanGrow = false;
		initializePool(objectToPool, size);
	}

	public ObjectPool(GameObject objectToPool, int size, bool ableToGrow)
	{ 
		CanGrow = ableToGrow;
		initializePool(objectToPool, size);
	}

	private void initializePool(GameObject objectToPool, int size)
	{
		pooledObject = objectToPool;
		m_pooledObjects = new List<GameObject>(size);
		
		for(int i = 0; i < size; i++)
		{
			addObjectToPool(pooledObject);
		}
	}

	public GameObject getPooledObject()
	{
		foreach(var pooledObj in m_pooledObjects)
		{
			if(!pooledObj.activeInHierarchy)
			{
				return pooledObj;
			}
		}

		if(CanGrow)
		{
			return addObjectToPool(pooledObject);
		}

		return null;
	}

	private GameObject addObjectToPool(GameObject objToPool)
	{
		GameObject newObj = (GameObject) Instantiate(objToPool);

		newObj.SetActive(false);

		m_pooledObjects.Add(newObj);
		
		return newObj;
	}
}
