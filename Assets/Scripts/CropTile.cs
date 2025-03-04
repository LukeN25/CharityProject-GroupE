
using UnityEngine;

public class CropTile : MonoBehaviour
{
    public bool isOccupied = false;
    public CropController currentCrop; 
    public GameObject cropPrefab;      

    
    public void PlantCrop()
    {
        if (isOccupied)
        {
            Debug.Log("CropTile: Tile is already occupied.");
            return;
        }

        if (ToolManager.Instance == null)
        {
            Debug.LogWarning("CropTile: ToolManager.Instance is null.");
            return;
        }

        if (ToolManager.Instance.currentTool == ToolManager.ToolType.Seeds &&
            ToolManager.Instance.heldSeed != ToolManager.SeedType.None)
        {
            
            GameObject cropObj = Instantiate(cropPrefab, transform.position, Quaternion.identity);
            CropController cropCtrl = cropObj.GetComponent<CropController>();

            if (cropCtrl != null)
            {
               
                cropCtrl.seedType = ToolManager.Instance.heldSeed;
               
                cropCtrl.UpdateCropAppearance();
               
                ToolManager.Instance.heldSeed = ToolManager.SeedType.None;
                isOccupied = true;
                currentCrop = cropCtrl;
                Debug.Log("CropTile: Planted crop with seed: " + cropCtrl.seedType);
            }
            else
            {
                Debug.LogError("CropTile: The cropPrefab does not have a CropController.");
            }
        }
        else
        {
            Debug.Log("CropTile: Cannot plant crop. Either tool is not Seeds or no seed is held.");
        }
    }

    public void WaterTile()
    {
        if (isOccupied && currentCrop != null)
        {
            currentCrop.StartWatering();
            Debug.Log("CropTile: Watering crop.");
        }
    }

    public void ShovelCrop()
    {
        if (isOccupied && currentCrop != null && currentCrop.CanBeHarvested)
        {
            currentCrop.StartHarvest();
            Debug.Log("CropTile: Harvesting crop.");
        }
    }

    public void RemoveCrop()
    {
        isOccupied = false;
        currentCrop = null;
    }
}
