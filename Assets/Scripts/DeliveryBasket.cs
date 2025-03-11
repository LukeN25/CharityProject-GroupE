
using UnityEngine;

public class DeliveryBasket : MonoBehaviour
{
    
    public void DeliverCrop(CropController crop)
    {
        if (TaskManager.Instance != null)
        {
            TaskManager.Instance.DeliverCrop(crop.seedType);
            if (crop.tile != null)
                crop.tile.RemoveCrop();
            Destroy(crop.gameObject);
            Debug.Log("DeliveryBasket: Delivered " + crop.seedType + " crop.");
        }
        else
        {
            Debug.LogError("DeliveryBasket: TaskManager.Instance is null.");
        }
    }
}
