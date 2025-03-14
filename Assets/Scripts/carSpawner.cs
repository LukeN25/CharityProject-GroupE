using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public float spawnRate = .3f;

    float TimeToSpawn = 0f;

    public GameObject car;

    public Transform[] spawnPoints;

    void Update()
    {

        if(TimeToSpawn <= Time.time)
        {
            SpawnCar();
            TimeToSpawn = Time.time + spawnRate;
        }
    }

    void SpawnCar()
    {
        int randomArray = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomArray];

        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}
