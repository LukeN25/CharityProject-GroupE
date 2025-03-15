using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BirdCounterScript : MonoBehaviour
{

    public TextMeshProUGUI birdCounterText;
    public int birdsSnapshotted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdsSnapshotted = 0;
        birdCounterText.text = "Birds: " + birdsSnapshotted.ToString() + "/7";

    }

    public void BirdNumberIncrease()
    {
        birdCounterText.text = birdsSnapshotted.ToString() + "/7";
    }

}
