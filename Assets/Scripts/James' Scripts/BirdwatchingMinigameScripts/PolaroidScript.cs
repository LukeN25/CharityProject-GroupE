using UnityEngine;

public class PolaroidScript : MonoBehaviour
{
    public GameObject bullfinchPolaroid;
    public GameObject magpiePolaroid;
    public GameObject starlingPolaroid;
    public GameObject robinPolaroid;
    public GameObject victoryText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*bullfinchPolaroid.SetActive(false);
        magpiePolaroid.SetActive(false);
        starlingPolaroid.SetActive(false);
        robinPolaroid.SetActive(false); */

        victoryText.SetActive(false);
        DisableAllPolaroids();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableBullfinchPolaroid()
    {
        bullfinchPolaroid.SetActive(true);
    }

    public void EnableMagpiePolaroid()
    {
        magpiePolaroid.SetActive(true);
    }

    public void EnableStarlingPolaroid()
    {
        starlingPolaroid.SetActive(true);
    }

    public void EnableRobinPolaroid() 
    { 
        robinPolaroid.SetActive(true);
    }

    public void EnableVictoryText()
    {
        victoryText.SetActive(true);
    }

    public void DisableAllPolaroids()
    {
        starlingPolaroid.SetActive(false);
        magpiePolaroid.SetActive(false);
        bullfinchPolaroid.SetActive(false);
        robinPolaroid.SetActive(false);
    }
}
