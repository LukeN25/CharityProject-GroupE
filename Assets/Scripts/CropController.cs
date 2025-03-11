
using UnityEngine;

public class CropController : MonoBehaviour
{
    public enum CropState { Growing, Finished }
    public CropState state = CropState.Growing;

    public SeedType seedType;  
    public CropTile tile;       

    public int mashThreshold = 20;  
    private int mashCount = 0;

    [Header("Appearance")]
    public Sprite potatoSprite;
    public Sprite tomatoSprite;
    public Sprite finishedSprite;   

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateAppearance();
    }

    public void PlantSeed(SeedType newSeed)
    {
        seedType = newSeed;
        state = CropState.Growing;
        mashCount = 0;
        UpdateAppearance();
        Debug.Log("CropController: Planted " + seedType + " seed.");
    }

   
    public void MashCrop()
    {
        if (state == CropState.Growing)
        {
            mashCount++;
            Debug.Log("CropController: Mash count " + mashCount + "/" + mashThreshold);
            if (mashCount >= mashThreshold)
            {
                state = CropState.Finished;
                UpdateAppearance();
                Debug.Log("CropController: Crop finished growing.");
            }
        }
    }

    public void UpdateAppearance()
    {
        if (sr != null)
        {
            if (state == CropState.Growing)
            {
                if (seedType == SeedType.Potato)
                    sr.sprite = potatoSprite;
                else if (seedType == SeedType.Tomato)
                    sr.sprite = tomatoSprite;
            }
            else if (state == CropState.Finished)
            {
                if (finishedSprite != null)
                    sr.sprite = finishedSprite;
            }
        }
    }
}
