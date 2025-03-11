using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    private TaskManager taskManager;

    void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToolManager.SeedType heldSeed = ToolManager.Instance.GetCurrentSeed();
            if (heldSeed != ToolManager.SeedType.None)
            {
                taskManager.DeliverCrop(heldSeed);
            }
        }
    }
}
