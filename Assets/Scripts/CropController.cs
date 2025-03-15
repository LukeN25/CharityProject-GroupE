using UnityEngine;
using UnityEngine.UI;
using System.Collections;



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

    [Header("Mashing Progress Bar")]
    public Image progressBar;  

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (progressBar != null)
        {
            progressBar.fillAmount = 0;
            progressBar.gameObject.SetActive(false);
        }
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
        if (state != CropState.Growing)
            return;
        mashCount++;
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(true);
            progressBar.fillAmount = (float)mashCount / mashThreshold;
        }
        Debug.Log("CropController: Mash count " + mashCount + "/" + mashThreshold);
        if (mashCount >= mashThreshold)
        {
            state = CropState.Finished;
            if (progressBar != null)
                progressBar.gameObject.SetActive(false);
            UpdateAppearance();
            Debug.Log("CropController: Crop finished growing.");
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
