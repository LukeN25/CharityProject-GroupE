using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText; 
    private int score = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        score++;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        Debug.Log("Score updated: " + score);
    }
}
