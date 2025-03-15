
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public float slipperyDuration = 3f;
    public float slipperyMultiplier = 0.5f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplySlipperyEffect(slipperyMultiplier, slipperyDuration);
                Debug.Log("Puddle: Applied slippery effect.");
            }
        }
    }
}
