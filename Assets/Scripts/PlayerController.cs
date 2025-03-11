
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    
    private CropTile currentTile;            
    private CropController currentPickupCrop; 
    private DeliveryBasket currentBasket;     

    
    public CropController heldCrop;

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
          
            if (currentBasket != null && heldCrop != null)
            {
                currentBasket.DeliverCrop(heldCrop);
                heldCrop = null;
            }
           
            else if (currentPickupCrop != null && heldCrop == null)
            {
                PickUpCrop(currentPickupCrop);
                currentPickupCrop = null;
            }
           
            else if (currentTile != null)
            {
                currentTile.PlantCrop();
            }
            else
            {
                Debug.Log("PlayerController: No interactable object available.");
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    private void PickUpCrop(CropController crop)
    {
        heldCrop = crop;
       
        crop.transform.SetParent(transform);
        crop.transform.localPosition = new Vector3(0, 1, 0); 
        Debug.Log("PlayerController: Picked up " + crop.seedType + " crop for delivery.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        CropTile tile = other.GetComponent<CropTile>();
        if (tile != null)
        {
            currentTile = tile;
            Debug.Log("PlayerController: Entered CropTile " + tile.gameObject.name);
        }

        
        CropController crop = other.GetComponent<CropController>();
        if (crop != null && crop.state == CropController.CropState.Harvested)
        {
            currentPickupCrop = crop;
            Debug.Log("PlayerController: Found harvested crop " + crop.seedType);
        }

        
        DeliveryBasket basket = other.GetComponent<DeliveryBasket>();
        if (basket != null)
        {
            currentBasket = basket;
            Debug.Log("PlayerController: Near DeliveryBasket.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CropTile tile = other.GetComponent<CropTile>();
        if (tile != null && tile == currentTile)
        {
            currentTile = null;
            Debug.Log("PlayerController: Exited CropTile " + tile.gameObject.name);
        }

        CropController crop = other.GetComponent<CropController>();
        if (crop != null && crop == currentPickupCrop)
        {
            currentPickupCrop = null;
            Debug.Log("PlayerController: Left harvested crop area.");
        }

        DeliveryBasket basket = other.GetComponent<DeliveryBasket>();
        if (basket != null && basket == currentBasket)
        {
            currentBasket = null;
            Debug.Log("PlayerController: Left DeliveryBasket area.");
        }
    }
}
