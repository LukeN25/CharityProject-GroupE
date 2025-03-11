
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    
    public SeedType currentSeed = SeedType.None;   
    public CropController heldCrop;                  

    
    private CropTile currentTile;        
    private CropController currentCrop;  
    private DeliveryTable currentDeliveryTable;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (currentDeliveryTable != null && heldCrop != null)
            {
                currentDeliveryTable.DeliverCrop(heldCrop);
                heldCrop = null;
            }
            
            
            
            else if (currentCrop != null)
            {
                if (currentCrop.state == CropController.CropState.Growing)
                {
                    currentCrop.MashCrop();
                }
                else if (currentCrop.state == CropController.CropState.Finished && heldCrop == null)
                {
                    PickUpCrop(currentCrop);
                }
            }
            
            else if (currentTile != null && currentSeed != SeedType.None)
            {
                currentTile.PlantCrop(currentSeed);
                currentSeed = SeedType.None;
            }
            else
            {
                Debug.Log("Player: No interactable object.");
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    public void PickUpSeed(SeedType seed)
    {
        currentSeed = seed;
        Debug.Log("Player: Picked up seed: " + seed);
    }

    private void PickUpCrop(CropController crop)
    {
        heldCrop = crop;
       
        crop.transform.SetParent(transform);
        crop.transform.localPosition = new Vector3(0, 1, 0); 
        Debug.Log("Player: Picked up finished crop: " + crop.seedType);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        CropTile tile = other.GetComponent<CropTile>();
        if (tile != null)
        {
            currentTile = tile;
            Debug.Log("Player: Entered CropTile " + tile.gameObject.name);
        }

        
        CropController crop = other.GetComponent<CropController>();
        if (crop != null)
        {
            currentCrop = crop;
            Debug.Log("Player: Detected crop " + crop.gameObject.name + " with state " + crop.state);
        }

       
        DeliveryTable table = other.GetComponent<DeliveryTable>();
        if (table != null)
        {
            currentDeliveryTable = table;
            Debug.Log("Player: Near DeliveryTable.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CropTile tile = other.GetComponent<CropTile>();
        if (tile != null && tile == currentTile)
        {
            currentTile = null;
            Debug.Log("Player: Exited CropTile " + tile.gameObject.name);
        }

        CropController crop = other.GetComponent<CropController>();
        if (crop != null && crop == currentCrop)
        {
            currentCrop = null;
            Debug.Log("Player: Left crop area " + crop.gameObject.name);
        }

        DeliveryTable table = other.GetComponent<DeliveryTable>();
        if (table != null && table == currentDeliveryTable)
        {
            currentDeliveryTable = null;
            Debug.Log("Player: Left DeliveryTable area.");
        }
    }
}
