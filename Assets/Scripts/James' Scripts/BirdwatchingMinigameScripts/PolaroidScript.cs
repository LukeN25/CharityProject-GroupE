using UnityEngine;

public class PolaroidScript : MonoBehaviour
{
    public GameObject bullfinchPolaroid;
    public GameObject magpiePolaroid;
    public GameObject starlingPolaroid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullfinchPolaroid.SetActive(false);
        magpiePolaroid.SetActive(false);
        starlingPolaroid.SetActive(false);
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
}
