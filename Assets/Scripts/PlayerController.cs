using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CropTile"))
        {
            CropTile tile = other.GetComponent<CropTile>();

            if (tile != null)
            {
                ToolManager.ToolType currentTool = ToolManager.Instance.GetCurrentTool();

                if (currentTool == ToolManager.ToolType.Seed) tile.Interact();
                if (currentTool == ToolManager.ToolType.WateringCan) tile.Interact();
                if (currentTool == ToolManager.ToolType.Shovel) tile.Interact();
            }
        }
    }
}
