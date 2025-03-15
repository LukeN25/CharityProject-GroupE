using System.Collections;
using UnityEngine;

public class PuddleSpawner : MonoBehaviour
{
    [Header("Puddle Spawning Settings")]
    public GameObject puddlePrefab;
    public float spawnIntervalMin = 7f;
    public float spawnIntervalMax = 10f;
    public float puddleLifetime = 10f;

    [Header("Spawn Area")]
    public Vector2 spawnAreaMin; 
    public Vector2 spawnAreaMax; 

    void Start()
    {
        StartCoroutine(SpawnPuddles());
    }

    IEnumerator SpawnPuddles()
    {
        while (true)
        {
            
            float waitTime = UnityEngine.Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);

            
            float x = UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPosition = new Vector2(x, y);

            
            GameObject puddle = Instantiate(puddlePrefab, spawnPosition, Quaternion.identity);
            puddle.transform.parent = transform; 

           
            Destroy(puddle, puddleLifetime);
        }
    }
}
