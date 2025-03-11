
using UnityEngine;

public class CropTile : MonoBehaviour
{
    public bool isOccupied = false;
    public GameObject cropPrefab; 
    private CropController currentCrop;

    public void PlantCrop()
    {
        Debug.Log("CropTile: Attempting to plant on " + gameObject.name);
        if (isOccupied)
        {
            Debug.Log("CropTile: Tile is already occupied.");
            return;
        }

        if (SeedInventoryManager.Instance == null)
        {
            Debug.LogError("CropTile: SeedInventoryManager.Instance is null.");
            return;
        }

        if (SeedInventoryManager.Instance.GetCurrentSeed() == SeedInventoryManager.SeedType.None)
        {
            Debug.Log("CropTile: No seed held.");
            return;
        }

        if (cropPrefab == null)
        {
            Debug.LogError("CropTile: cropPrefab is not assigned!");
            return;
        }

        GameObject cropObj = Instantiate(cropPrefab, transform.position, Quaternion.identity);
        CropController cropCtrl = cropObj.GetComponent<CropController>();
        if (cropCtrl != null)
        {
            cropCtrl.tile = this;
            cropCtrl.PlantSeed(SeedInventoryManager.Instance.GetCurrentSeed());
            isOccupied = true;
            currentCrop = cropCtrl;
            Debug.Log("CropTile: Planted " + SeedInventoryManager.Instance.GetCurrentSeed() + " seed.");
            SeedInventoryManager.Instance.ClearSeed();
        }
        else
        {
            Debug.LogError("CropTile: cropPrefab does not have a CropController.");
        }
    }

    public void RemoveCrop()
    {
        isOccupied = false;
        currentCrop = null;
    }
}
