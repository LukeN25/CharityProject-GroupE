using System.Collections;

using UnityEngine;

public class SeedPickup : MonoBehaviour
{
    public SeedInventoryManager.SeedType seedType;  
    public float respawnTime = 5f;  

    private Collider2D col;
    private SpriteRenderer sr;

    void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        if (col == null)
            Debug.LogError("SeedPickup: No Collider2D on " + gameObject.name);
        else if (!col.isTrigger)
            Debug.LogWarning("SeedPickup: Collider2D on " + gameObject.name + " should be set as Trigger.");

        if (sr == null)
            Debug.LogError("SeedPickup: No SpriteRenderer on " + gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SeedPickup: Trigger entered by " + other.name);
        if (other.CompareTag("Player"))
        {
            if (SeedInventoryManager.Instance != null)
            {
                SeedInventoryManager.Instance.PickUpSeed(seedType);
                StartCoroutine(Respawn());
            }
            else
            {
                Debug.LogError("SeedPickup: SeedInventoryManager.Instance is null.");
            }
        }
    }

    private IEnumerator Respawn()
    {
        col.enabled = false;
        sr.enabled = false;
        Debug.Log("SeedPickup: Hiding seed pickup.");
        yield return new WaitForSeconds(respawnTime);
        col.enabled = true;
        sr.enabled = true;
        Debug.Log("SeedPickup: Seed pickup has respawned.");
    }
}
