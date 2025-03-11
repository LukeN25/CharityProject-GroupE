using UnityEngine;
using System.Collections;


public class CropController : MonoBehaviour
{
    public enum CropState { Planted, Watered, Harvested }
    public CropState state = CropState.Planted;

    
    public SeedInventoryManager.SeedType seedType;
    public CropTile tile;  

    [Header("Timings")]
    public float waterDelay = 3f;    
    public float harvestDelay = 3f; 

    [Header("Appearance")]
    public Sprite potatoSprite;
    public Sprite tomatoSprite;
    public Sprite harvestedSprite;   

   
    public Transform progressBar;

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.localScale = new Vector3(0f, 1f, 1f);
            progressBar.gameObject.SetActive(false);
        }
        UpdateCropAppearance();
        StartCoroutine(LifeCycle());
    }

    IEnumerator LifeCycle()
    {
        yield return new WaitForSeconds(waterDelay);
        WaterCrop();
        yield return new WaitForSeconds(harvestDelay);
        HarvestCrop();
    }

    public void PlantSeed(SeedInventoryManager.SeedType newSeed)
    {
        seedType = newSeed;
        state = CropState.Planted;
        UpdateCropAppearance();
        Debug.Log("CropController: Planted " + seedType + " seed.");
    }

    public void WaterCrop()
    {
        if (state == CropState.Planted)
        {
            state = CropState.Watered;
            Debug.Log("CropController: Crop watered.");
            UpdateCropAppearance();
        }
    }

    public void HarvestCrop()
    {
        if (state == CropState.Watered)
        {
            state = CropState.Harvested;
            Debug.Log("CropController: Crop harvested and ready for delivery.");
            UpdateCropAppearance();
        }
    }

    public void UpdateCropAppearance()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            if (state == CropState.Planted)
            {
                if (seedType == SeedInventoryManager.SeedType.Potato)
                    sr.sprite = potatoSprite;
                else if (seedType == SeedInventoryManager.SeedType.Tomato)
                    sr.sprite = tomatoSprite;
            }
            else if (state == CropState.Harvested && harvestedSprite != null)
            {
                sr.sprite = harvestedSprite;
            }
        }
    }
}
