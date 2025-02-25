using UnityEngine;
using System.Collections;

public class CropController : MonoBehaviour
{
    [Header("Timing Settings")]
    public float timeToWither = 10f;    
    public float harvestDelay = 3f;     

    [HideInInspector]
    public CropTile tile;               

    private float timer = 0f;
    private bool isWatered = false;
    private bool isHarvesting = false;

    
    public bool CanBeHarvested
    {
        get { return isWatered && !isHarvesting; }
    }

    void Update()
    {
       
        if (isWatered && !isHarvesting)
        {
            timer += Time.deltaTime;
            if (timer >= timeToWither)
            {
                
                GameManager.Instance.GameOver();
               
            }
        }
    }

    
    public void Water()
    {
        isWatered = true;
        timer = 0f;  
    }

    
    public void StartHarvest()
    {
        if (CanBeHarvested)
        {
            isHarvesting = true;
            StartCoroutine(HarvestRoutine());
        }
    }

   
    IEnumerator HarvestRoutine()
    {
        yield return new WaitForSeconds(harvestDelay);
        GameManager.Instance.AddScore();
        tile.RemoveCrop();
        Destroy(gameObject);
    }
}
