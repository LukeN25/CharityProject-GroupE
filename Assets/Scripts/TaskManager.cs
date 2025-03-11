
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public int requiredPotatoes;
    public int requiredTomatoes;

    private int collectedPotatoes = 0;
    private int collectedTomatoes = 0;

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
        requiredPotatoes = UnityEngine.Random.Range(1, 4);
        requiredTomatoes = UnityEngine.Random.Range(1, 4);
        collectedPotatoes = 0;
        collectedTomatoes = 0;
        Debug.Log($"New Task: Deliver {requiredPotatoes} Potatoes and {requiredTomatoes} Tomatoes!");
    }

    public void DeliverCrop(SeedType cropType)
    {
        if (cropType == SeedType.Potato)
        {
            collectedPotatoes++;
            Debug.Log("TaskManager: Delivered Potato. Total: " + collectedPotatoes);
        }
        else if (cropType == SeedType.Tomato)
        {
            collectedTomatoes++;
            Debug.Log("TaskManager: Delivered Tomato. Total: " + collectedTomatoes);
        }
        CheckTaskCompletion();
    }

    void CheckTaskCompletion()
    {
        if (collectedPotatoes >= requiredPotatoes && collectedTomatoes >= requiredTomatoes)
        {
            Debug.Log("TaskManager: Task Complete! Generating new task...");
            GenerateNewTask();
        }
    }
}
