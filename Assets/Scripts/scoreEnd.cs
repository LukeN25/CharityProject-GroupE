using UnityEngine;
using TMPro;

public class scoreEnd : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "SCORE: " + Score.yourScore.ToString();
    }
}