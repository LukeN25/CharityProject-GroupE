using UnityEngine;

public class FireHazardObject : MonoBehaviour
{
    public FireHazardManager fireHazardManager;


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
}
