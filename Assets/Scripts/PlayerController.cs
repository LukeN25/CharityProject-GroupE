using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

   
    private CropTile currentTile;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
        if (Input.GetKeyDown(KeyCode.E) && currentTile != null)
        {
            
            if (ToolManager.Instance.currentTool == ToolType.WateringCan)
            {
                currentTile.WaterTile();
            }
            else if (ToolManager.Instance.currentTool == ToolType.Shovel)
            {
                currentTile.ShovelCrop();
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        CropTile tile = other.GetComponent<CropTile>();
        if (tile != null)
        {
            currentTile = tile;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CropTile tile = other.GetComponent<CropTile>();
        if (tile != null && tile == currentTile)
        {
            currentTile = null;
        }
    }
}
