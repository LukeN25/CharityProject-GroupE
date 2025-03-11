using UnityEngine;

public class CropTile : MonoBehaviour
{
    private CropController crop;

    void Start()
    {
        crop = GetComponentInChildren<CropController>();
    }

    public void Interact()
    {
        if (crop == null) return;

        ToolManager.ToolType currentTool = ToolManager.Instance.GetCurrentTool();
        ToolManager.SeedType currentSeed = ToolManager.Instance.GetCurrentSeed();

        if (currentTool == ToolManager.ToolType.Seed && crop.CanPlantSeed())
        {
            crop.PlantSeed(currentSeed);
        }
        else if (currentTool == ToolManager.ToolType.WateringCan && crop.CanBeWatered)
        {
            crop.WaterCrop();
        }
        else if (currentTool == ToolManager.ToolType.Shovel && crop.CanBeHarvested)
        {
            crop.HarvestCrop();
        }
    }
}
