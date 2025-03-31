using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireHazardManager : MonoBehaviour
{

    public int fireHazards = 6;

    public int fireHazardsFound;

    public TextMeshProUGUI fireHazardsFoundText;

    public TextMeshProUGUI pressToFinishGameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pressToFinishGameText.enabled = false;
        fireHazardsFound = 0;
        fireHazardsFoundText.text = "Fire Hazards: " + fireHazardsFound.ToString() + "/7";
    }

    // Update is called once per frame
    void Update()
    {
        if ( fireHazardsFound == fireHazards )
        {
            pressToFinishGameText.enabled = true;

            if(Input.GetKeyDown(KeyCode.F))
            {
                //When scenes are compiled just uncomment the line of code below
               // SceneManager.LoadScene(MainMenuScene);
            }
        }
    }

    public void FoundFireHazard()
    {
        fireHazardsFound++;
        fireHazardsFoundText.text = "Fire Hazards: " + fireHazardsFound.ToString() + "/6";
    }
}
