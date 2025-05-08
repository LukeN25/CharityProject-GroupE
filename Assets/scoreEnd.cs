using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreEnded : MonoBehaviour
{
    public static int yourScore = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "SCORE: " + yourScore.ToString();
    }
}