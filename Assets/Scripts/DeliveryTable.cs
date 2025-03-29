
using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    private TaskManager taskManager;

    void Start()
    {
        taskManager = TaskManager.Instance;
    }

    
    public void DeliverCrop(CropController crop)
    {
        if (taskManager != null)
        {
            taskManager.DeliverCrop(crop.seedType);
            if (crop.tile != null)
                crop.tile.RemoveCrop();
            Destroy(crop.gameObject);
            Debug.Log("DeliveryTable: Delivered " + crop.seedType + " crop.");
        }
        else
        {
            Debug.LogError("DeliveryTable: TaskManager.Instance is null.");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
     
    }
}
