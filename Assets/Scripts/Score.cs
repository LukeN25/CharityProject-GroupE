using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int yourScore = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "STEPS: " + yourScore.ToString();
    }
}