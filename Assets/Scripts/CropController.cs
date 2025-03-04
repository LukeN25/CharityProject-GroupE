using UnityEngine;
using System.Collections;

public class CropController : MonoBehaviour
{
    [Header("Timings")]
    public float waterDelay = 3f;    
    public float harvestDelay = 3f;  

    [HideInInspector]
    public CropTile tile;  

    
    public ToolManager.SeedType seedType;

    [Header("Crop Appearance")]
    public Sprite potatoSprite;  
    public Sprite tomatoSprite;  

    
    public Transform progressBar;

    private bool isWatered = false;
    private bool isHarvesting = false;

    public bool CanBeHarvested { get { return isWatered && !isHarvesting; } }

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.localScale = new Vector3(0f, 1f, 1f);
            progressBar.gameObject.SetActive(false);
        }
    }

    
    public void UpdateCropAppearance()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            if (seedType == ToolManager.SeedType.Potato)
                sr.sprite = potatoSprite;
            else if (seedType == ToolManager.SeedType.Tomato)
                sr.sprite = tomatoSprite;
        }
    }

    public void StartWatering()
    {
        if (!isWatered)
        {
            StartCoroutine(WateringRoutine());
        }
    }

    IEnumerator WateringRoutine()
    {
        if (progressBar != null)
            progressBar.gameObject.SetActive(true);

        float timer = 0f;
        while (timer < waterDelay)
        {
            timer += Time.deltaTime;
            if (progressBar != null)
                progressBar.localScale = new Vector3(timer / waterDelay, 1f, 1f);
            yield return null;
        }

        isWatered = true;
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false);
            progressBar.localScale = new Vector3(0f, 1f, 1f);
        }
    }

    public void StartHarvest()
    {
        if (CanBeHarvested)
        {
            StartCoroutine(HarvestRoutine());
        }
    }

    IEnumerator HarvestRoutine()
    {
        isHarvesting = true;
        if (progressBar != null)
            progressBar.gameObject.SetActive(true);

        float timer = 0f;
        while (timer < harvestDelay)
        {
            timer += Time.deltaTime;
            if (progressBar != null)
                progressBar.localScale = new Vector3(timer / harvestDelay, 1f, 1f);
            yield return null;
        }

       
        GameManager.Instance.AddScore();
        tile.RemoveCrop();
        Destroy(gameObject);
    }
}
