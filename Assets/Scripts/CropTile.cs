using UnityEngine;

public class CropTile : MonoBehaviour
{
    public bool isOccupied = false;
    public CropController currentCrop; 

    
    public void WaterTile()
    {
        if (!isOccupied)
        {
            
            GameObject cropObj = Instantiate(GameManager.Instance.cropPrefab, transform.position, Quaternion.identity);
            currentCrop = cropObj.GetComponent<CropController>();
            currentCrop.tile = this;
            isOccupied = true;
            currentCrop.Water(); 
        }
    }

    
    public void ShovelCrop()
    {
        if (isOccupied && currentCrop != null && currentCrop.CanBeHarvested)
        {
            currentCrop.StartHarvest(); 
        }
    }

    
    public void RemoveCrop()
    {
        isOccupied = false;
        currentCrop = null;
    }
}
