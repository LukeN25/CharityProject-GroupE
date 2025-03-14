using UnityEngine;
using UnityEngine.SceneManagement;

public class frogWin : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        Debug.Log("Win!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
