using UnityEngine;
using UnityEngine.SceneManagement;

public class stepCounterAdd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Score.yourScore += 1;
        Destroy(gameObject);
    }
}