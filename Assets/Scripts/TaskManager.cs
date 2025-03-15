
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public int requiredPotatoes;
    public int requiredTomatoes;

    private int collectedPotatoes = 0;
    private int collectedTomatoes = 0;
    public int difficultyLevel = 1;

    public int CollectedPotatoes => collectedPotatoes;
    public int CollectedTomatoes => collectedTomatoes;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        GenerateNewTask();
    }

    void GenerateNewTask()
    {
        
        requiredPotatoes = UnityEngine.Random.Range(2, 3 + difficultyLevel); 
        requiredTomatoes = UnityEngine.Random.Range(3, 5 + difficultyLevel);
        collectedPotatoes = 0;
        collectedTomatoes = 0;
        Debug.Log($"New Task: Deliver {requiredPotatoes} Potatoes and {requiredTomatoes} Tomatoes!");
    }

    
    public void DeliverCrop(SeedType cropType)
    {
        if (cropType == SeedType.Potato)
        {
            collectedPotatoes++;
            Debug.Log("Delivered Potato. Total: " + collectedPotatoes);
        }
        else if (cropType == SeedType.Tomato)
        {
            collectedTomatoes++;
            Debug.Log("Delivered Tomato. Total: " + collectedTomatoes);
        }
        CheckTaskCompletion();
    }

    void CheckTaskCompletion()
    {
        if (collectedPotatoes >= requiredPotatoes && collectedTomatoes >= requiredTomatoes)
        {
            Debug.Log("Task Complete! Generating new task...");
            GenerateNewTask();
        }
    }
}
