using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform camTransform;
    bool camLeftRight = true;

    public GameObject Cam1Text;
    public GameObject Cam2Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            camLeftRight = false;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            camLeftRight = true;
        }

        if(camLeftRight)
        {
            camTransform.position = new Vector3(0, 0, -10);
            Cam1Text.SetActive(true);
            Cam2Text.SetActive(false);
        }
        else
        {
            camTransform.position = new Vector3(18, 0, -10);
            Cam1Text.SetActive(false);
            Cam2Text.SetActive(true);
        }
    }
}
