using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public DayNightCycle dnc;
    public GameObject spawneE;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public float enemiesSpawned;
    public float allowedenemy;
    

    private void Start()
    {
        enemiesSpawned = 0;
        dnc = gameObject.GetComponent<DayNightCycle>();
    }


    private void FixedUpdate()
    {
        if (dnc.timeOfDay > 0.8f || dnc.timeOfDay < 0.2f)
        {
            stopSpawning = false;
            if (enemiesSpawned >= 1)
            {
                while (enemiesSpawned > 1)
                    Destroy(spawneE);
                stopSpawning = true;
            }
            else if ( enemiesSpawned < 1)
            {
                InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
                enemiesSpawned++;
                Debug.Log("spawned");
            }

        }
        else
        {
            stopSpawning = true;
            while (enemiesSpawned > 0)
                Destroy(spawneE);
        }

    }
    public void SpawnObject()
    {
        Instantiate(spawneE, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }


}
