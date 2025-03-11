
using UnityEngine;

public class CropController : MonoBehaviour
{
    public ToolManager.SeedType seedType;
    private bool isPlanted = false;
    private bool isWatered = false;
    private bool isReadyToHarvest = false;

    public bool CanPlantSeed() => !isPlanted;
    public bool CanBeWatered => isPlanted && !isWatered;
    public bool CanBeHarvested => isReadyToHarvest;

    public void PlantSeed(ToolManager.SeedType newSeed)
    {
        if (!isPlanted)
        {
            isPlanted = true;
            seedType = newSeed;
            Debug.Log($"Planted {seedType} seed.");
        }
    }

    public void WaterCrop()
    {
        if (isPlanted && !isWatered)
        {
            isWatered = true;
            isReadyToHarvest = true;
            Debug.Log($"Watered {seedType} crop.");
        }
    }

    public void HarvestCrop()
    {
        if (isReadyToHarvest)
        {
            Debug.Log($"Harvested {seedType} crop.");
            Destroy(gameObject);
        }
    }
}
