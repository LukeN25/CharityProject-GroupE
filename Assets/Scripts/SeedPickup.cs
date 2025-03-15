using System.Collections;

using UnityEngine;

public class SeedPickup : MonoBehaviour
{
    public SeedType seedType;  
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
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.PickUpSeed(seedType);
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn()
    {
        col.enabled = false;
        sr.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        col.enabled = true;
        sr.enabled = true;
    }
}
