
using UnityEngine;

public class CropTile : MonoBehaviour
{
    public bool isOccupied = false;
    public GameObject cropPrefab;  

    public void PlantCrop(SeedType seed)
    {
        Debug.Log("CropTile: Planting " + seed + " on " + gameObject.name);
        if (isOccupied)
        {
            Debug.Log("CropTile: Already occupied.");
            return;
        }
        if (cropPrefab == null)
        {
            Debug.LogError("CropTile: cropPrefab not assigned!");
            return;
        }
        GameObject cropObj = Instantiate(cropPrefab, transform.position, Quaternion.identity);
        CropController cropCtrl = cropObj.GetComponent<CropController>();
        if (cropCtrl != null)
        {
            cropCtrl.tile = this;
            cropCtrl.PlantSeed(seed);
            isOccupied = true;
        }
        else
        {
            Debug.LogError("CropTile: cropPrefab missing CropController!");
        }

    }

    public void RemoveCrop()
    {
        isOccupied = false;
    }
}
