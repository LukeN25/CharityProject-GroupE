using UnityEngine;
using UnityEngine.SceneManagement;

public class winCounter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.yourScore += 1;
    }
}
