using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public int xPosLower = -7;
    public int xPosUpper = 7;
    public int yVelLower = 9;
    public int yVelUpper = 14;
    public int xVelLower = -4;
    public int xVelUpper = 4;

    public BirdCounterScript birdCounterScript;
    public TakeSnapshot takeSnapshot;
    //public Image birdImage;
   // public Text birdText;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Random.Range(xPosLower, xPosUpper);
        float yVel = Random.Range(yVelLower, yVelUpper);
        float xVel = Random.Range(xVelLower, xVelUpper);

        if (this.transform.position.y < -6)
        {
            xPos = Random.Range(xPosLower, xPosUpper);

            if (xPos < -3)
                xVel = Random.Range(xVelLower, xVelUpper);
            if (xPos > 3)
                xVel = Random.Range(xVelLower * -1, xVelUpper * -1);

            this.transform.position = new Vector2(xPos, -6);

            this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(xVel, yVel);
        }


    }

    

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
           takeSnapshot.StartCoroutine(takeSnapshot.TakeSnapshotAndShow());
           // StartCoroutine(TakeSnapshotAndShow());
            Debug.Log("Bird clicked");
            Debug.Log("Screenshot should happen");
            birdCounterScript.birdsSnapshotted++;
            birdCounterScript.BirdNumberIncrease();
            DontDeleteBirdYet();
            Destroy(this.gameObject, 1.0f);
        }
    }

    private IEnumerator DontDeleteBirdYet()
    {
        yield return new WaitForSeconds(3);

    }

    
}