using UnityEngine;
using UnityEngine.SceneManagement;

public class frogWin : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.yourScore += 1;
    }
}
