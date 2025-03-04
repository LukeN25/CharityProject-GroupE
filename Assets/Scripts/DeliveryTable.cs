using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToolManager toolManager = other.GetComponent<ToolManager>();
            if (toolManager != null && toolManager.currentTool == ToolManager.ToolType.Seeds)
            {
                TaskManager taskManager = FindObjectOfType<TaskManager>(); 
                taskManager.DeliverCrop(toolManager.heldSeed);
                toolManager.heldSeed = ToolManager.SeedType.None; 
            }
        }
    }
}
