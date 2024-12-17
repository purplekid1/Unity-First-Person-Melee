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
    public float enemiesSpawned = 0;


    private void Start()
    {
        stopSpawning = true;
        
        dnc = GameObject.Find("TimeManagement").GetComponentInChildren<DayNightCycle>();
    }


    private void FixedUpdate()
    {
        if (dnc.timeOfDay <= 0.8f && dnc.timeOfDay >= 0.2f)
        {
            stopSpawning = true;
        }
        else
        {
            stopSpawning = false;
            if (enemiesSpawned >= 1f)
            {
                stopSpawning = true;
            } 
            else
            {
                InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
                enemiesSpawned++;
            }
            
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
