using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float startTime = 120f;  
    private float currentTime;
    public TextMeshProUGUI timerText;  

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }
        if (timerText != null)
            timerText.text = Mathf.Ceil(currentTime).ToString();
    }

    
    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd;
    }

    void GameOver()
    {
        UIManager.Instance.ShowGameOverScreen();
        Time.timeScale = 0;  
    }
}
