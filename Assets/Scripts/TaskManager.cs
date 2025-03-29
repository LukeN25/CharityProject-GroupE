using UnityEngine;
using TMPro;
using System.Collections;


public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [Header("Task Settings")]
    public int requiredPotatoes = 2;
    public int requiredTomatoes = 3;
    private int collectedPotatoes = 0;
    private int collectedTomatoes = 0;

    
    public int CollectedPotatoes { get { return collectedPotatoes; } }
    public int CollectedTomatoes { get { return collectedTomatoes; } }

    [Header("UI & Timer Settings")]
    public TextMeshProUGUI taskPromptText;   
    public float taskPromptDuration = 5f;     
    public GameTimer gameTimer;              
    public float extraTimePerTask = 30f;      

    [Header("Audio Settings")]
    public AudioSource audioSource;          
    public AudioClip mashSound;              
    public AudioClip cropCompleteSound;     
    public AudioClip deliverySound;          
    public AudioClip taskCompleteSound;      
    public AudioClip pickupSound;            
    public AudioClip puddleSound;            

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
       
        requiredPotatoes = UnityEngine.Random.Range(2, 5);  
        requiredTomatoes = UnityEngine.Random.Range(3, 6);  
        collectedPotatoes = 0;
        collectedTomatoes = 0;
        DisplayTaskPrompt($"New Task: Deliver {requiredPotatoes} Potatoes and {requiredTomatoes} Tomatoes!");

        
        if (gameTimer != null)
            gameTimer.AddTime(extraTimePerTask);
    }

    void DisplayTaskPrompt(string message)
    {
        if (taskPromptText != null)
        {
            taskPromptText.text = message;
            taskPromptText.gameObject.SetActive(true);
            StartCoroutine(HideTaskPromptAfterDelay());
        }
    }

    IEnumerator HideTaskPromptAfterDelay()
    {
        yield return new WaitForSeconds(taskPromptDuration);
        if (taskPromptText != null)
            taskPromptText.gameObject.SetActive(false);
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
        if (audioSource != null && deliverySound != null)
            audioSource.PlayOneShot(deliverySound);
        CheckTaskCompletion();
    }

    void CheckTaskCompletion()
    {
        if (collectedPotatoes >= requiredPotatoes && collectedTomatoes >= requiredTomatoes)
        {
            if (audioSource != null && taskCompleteSound != null)
                audioSource.PlayOneShot(taskCompleteSound);
            Debug.Log("TaskManager: Task Complete! Generating new task...");
            GenerateNewTask();
        }
    }
}
