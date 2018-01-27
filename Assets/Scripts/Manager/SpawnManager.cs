using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public PlayerController player; // Reference to the player controller
    public float spawnTime = 3.0f;
    public GameObject enemy;
    public int enemyPoolSize;
    public List<Transform> spawnPoints;


    ObjectPool spawnPool;

	// Use this for initialization
	void Start ()
    {
        Random.InitState( (int) System.DateTime.Now.Ticks );
        spawnPool = new ObjectPool(enemy, enemyPoolSize, true);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    void Spawn()
    {
        if(player.IsDead())
        {
            return;
        }
        
        int iSpawnLocation = Random.Range(0, spawnPoints.Count);
        GameObject spawnObj = spawnPool.getPooledObject();

        Debug.Log("Spawning object [" + spawnObj.name + ", " + spawnPoints[iSpawnLocation].position + "]");
        spawnObj.transform.position = spawnPoints[iSpawnLocation].position;
        spawnObj.transform.rotation = spawnPoints[iSpawnLocation].rotation;
        spawnObj.SetActive(true);
    }

}
