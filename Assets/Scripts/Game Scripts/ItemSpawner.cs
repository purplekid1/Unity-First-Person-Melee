using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public bool canSpawnItem = false;
    public float spawnTime = 10f;
    public int ItemCount = 0;
    public int ItemSpawn = 0;
    public Transform[] itemSpawnLocations;
    public GameObject SeedPrefab;
    public List<GameObject> spawnedItem;
    private float spawnedAt;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningItem());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawningItem()
    {
        while (canSpawnItem)
        {
            yield return new WaitForSeconds(spawnTime);
            for (int i = 0; i < ItemCount; i++)
            {
                GameObject obj = Instantiate(SeedPrefab, itemSpawnLocations[Random.Range(0, itemSpawnLocations.Length)].position, Quaternion.identity);
                spawnedItem.Add(obj);
            }
            spawnedAt = Time.time;
            yield return new WaitUntil(() => spawnedItem.TrueForAll((GameObject obj) => obj == null) || Time.time > spawnedAt + 180);
            spawnedItem.Clear();
        }
    }
}
