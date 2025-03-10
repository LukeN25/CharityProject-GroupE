
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [Header("Task Requirements")]
    public int requiredPotatoes;
    public int requiredTomatoes;

    private int collectedPotatoes = 0;
    private int collectedTomatoes = 0;

    public int CollectedPotatoes { get { return collectedPotatoes; } }
    public int CollectedTomatoes { get { return collectedTomatoes; } }

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
        Debug.Log($"New Task: Bring {requiredPotatoes} Potatoes and {requiredTomatoes} Tomatoes!");
    }

   
    public void DeliverCrop(ToolManager.SeedType cropType)
    {
        if (cropType == ToolManager.SeedType.Potato)
        {
            collectedPotatoes++;
            Debug.Log("Delivered a Potato. Total: " + collectedPotatoes);
        }
        else if (cropType == ToolManager.SeedType.Tomato)
        {
            collectedTomatoes++;
            Debug.Log("Delivered a Tomato. Total: " + collectedTomatoes);
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
