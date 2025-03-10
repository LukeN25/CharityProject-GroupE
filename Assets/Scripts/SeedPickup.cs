using UnityEngine;
using System.Collections;


public class SeedPickup : MonoBehaviour
{
   
    public ToolManager.SeedType seedType;
    public float respawnTime = 10f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("SeedPickup: Player collided with seed pickup.");
            if (ToolManager.Instance != null)
            {
                ToolManager.Instance.heldSeed = seedType;
                ToolManager.Instance.currentTool = ToolManager.ToolType.Seeds;
                Debug.Log("SeedPickup: Picked up seed: " + seedType.ToString());
                StartCoroutine(Respawn());
            }
        }
    }

    IEnumerator Respawn()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        gameObject.SetActive(true);
    }
}
