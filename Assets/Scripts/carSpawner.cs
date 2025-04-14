using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public float spawnRate = .3f;

    float TimeToSpawn = 0f;

    public GameObject[] cars;

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
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        int randomCarIndex = Random.Range(0, cars.Length);
        GameObject selectedCar = cars[randomCarIndex];

        Instantiate(selectedCar, spawnPoint.position, spawnPoint.rotation);
    }
}
