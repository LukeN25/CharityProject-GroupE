using System.Collections;
using UnityEngine;

public class FireHazardObject : MonoBehaviour
{
    public FireHazardManager fireHazardManager;
    public SpriteRenderer SpriteRenderer;
    public Animation anim;

    public int hazardTimerInt;

    private void Start()
    {
        SpriteRenderer.enabled = false;
    }

    private void Update()
    {
        StartCoroutine(hazardTimer());
    }

    //This variable will be for info popups that will tell the player why what they clicked was a fire safety hazard
    //public GameObject fireHazardInfoText;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Will add stuff like the sprite glowing when mouse hovers over when sprites are added
            Debug.Log("Fire hazard object clicked");
            fireHazardManager.FoundFireHazard();
            Destroy(this.gameObject);
        }
    }

    private IEnumerator hazardTimer()
    {
        yield return new WaitForSeconds(hazardTimerInt);
        
        //Until we have animations we'll just run this code to turn on the sprite
        SpriteRenderer.enabled = true;

        //This is the actual code for playing the hazard animation
        //anim.Play();
    }
}
