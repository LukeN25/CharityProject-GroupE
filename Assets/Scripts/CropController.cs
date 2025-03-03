using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CropController : MonoBehaviour
{
    [Header("Timings")]
    public float waterDelay = 3f;   
    public float harvestDelay = 3f; 

    [HideInInspector]
    public CropTile tile;           

    
    public Image progressBar;

    private bool isWatered = false;
    private bool isHarvesting = false;

   
    public bool CanBeHarvested
    {
        get { return isWatered && !isHarvesting; }
    }

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.fillAmount = 0f;
            progressBar.gameObject.SetActive(false);
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
        {
            progressBar.gameObject.SetActive(true);
        }

        float timer = 0f;
        while (timer < waterDelay)
        {
            timer += Time.deltaTime;
            if (progressBar != null)
                progressBar.fillAmount = timer / waterDelay;
            yield return null;
        }

        isWatered = true;

        
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false);
            progressBar.fillAmount = 0f;
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
        {
            progressBar.gameObject.SetActive(true);
        }

        float timer = 0f;
        while (timer < harvestDelay)
        {
            timer += Time.deltaTime;
            if (progressBar != null)
                progressBar.fillAmount = timer / harvestDelay;
            yield return null;
        }

       
        GameManager.Instance.AddScore();
        tile.RemoveCrop();
        Destroy(gameObject);
    }
}
