using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        var target = GameObject.Find("Crosshair");

        target.transform.position = new Vector3(pos.x, pos.y, -9);
    }
}
