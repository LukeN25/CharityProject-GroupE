using System.Collections;

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

    private bool isSlippery = false;
    private float slipperyMultiplier = 1f;

    // *** NEW VARIABLES FOR ANIMATION ***
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // *** INITIALIZE ANIMATOR AND SPRITERENDERER ***
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // *** CALL THE UPDATEANIMATION METHOD ***
        UpdateAnimation();

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
                Debug.Log("Player: No interactable object available.");
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed * slipperyMultiplier;
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

    public void ApplySlipperyEffect(float multiplier, float duration)
    {
        StartCoroutine(SlipperyCoroutine(multiplier, duration));
    }

    private IEnumerator SlipperyCoroutine(float multiplier, float duration)
    {
        isSlippery = true;
        slipperyMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        isSlippery = false;
        slipperyMultiplier = 1f;
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
            Debug.Log("Player: Detected crop " + crop.gameObject.name + " (state: " + crop.state + ")");
            if (crop.state == CropController.CropState.Finished)
            {
                currentCrop = crop;
            }
            else if (crop.state == CropController.CropState.Growing)
            {
                currentCrop = crop;
            }
        }

        DeliveryTable table = other.GetComponent<DeliveryTable>();
        if (table != null)
        {
            currentDeliveryTable = table;
            Debug.Log("Player: Near DeliveryTable.");
        }

        Puddle puddle = other.GetComponent<Puddle>();
        if (puddle != null)
        {
            ApplySlipperyEffect(puddle.slipperyMultiplier, puddle.slipperyDuration);
            Debug.Log("Player: Entered a puddle.");
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

    // *** NEW METHOD FOR HANDLING ANIMATION ***
    private void UpdateAnimation()
    {
        // Check horizontal movement
        if (movement.x > 0)
        {
            // Walking right normally
            animator.Play("WalkRight");
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            // Walking left using the same animation but flipped
            animator.Play("WalkRight");
            spriteRenderer.flipX = true;
        }
        else if (movement.y > 0)
        {
            // Walking up
            animator.Play("WalkUp");
            // Reset horizontal flip if needed
            spriteRenderer.flipX = false;
        }
        else if (movement.y < 0)
        {
            // Walking down
            animator.Play("WalkDown");
            // Reset horizontal flip if needed
            spriteRenderer.flipX = false;
        }
        else
        {
            // When no input is detected, play idle animation
            animator.Play("Idle");
        }
    }
}
