using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TakeSnapshot : MonoBehaviour
{

    [SerializeField] Image whereToShowSnapshot;
    [SerializeField] Image snapshotPolaroidBorder;

    public IEnumerator TakeSnapshotAndShow()
    {
        whereToShowSnapshot.enabled = false;
        snapshotPolaroidBorder.enabled = false;
        Debug.Log("Snapshot process started");
        yield return new WaitForEndOfFrame();

        Texture2D snapshot = ScreenCapture.CaptureScreenshotAsTexture();


        //This code is to deal with a Unity bug that fucks with the original screenshot, this isn't anything to do with the code being wrong
        //this is a workaround for a bug Unity STILL hasn't fixed after 2 years, it essentially just gets the raw data of the original screenshot
        //and displays it before Unitys buggy "colour correction" can fuck with it
        Texture2D newSnapshot = new Texture2D(snapshot.width, snapshot.height, TextureFormat.RGB24, false);
        newSnapshot.SetPixels(snapshot.GetPixels()); 
        newSnapshot.Apply();    

        Destroy(snapshot);

        Sprite snapshotSprite = Sprite.Create(newSnapshot, new Rect(0, 0, newSnapshot.width, newSnapshot.height), new Vector2(0.5f,0.5f));

        whereToShowSnapshot.enabled = true;
        snapshotPolaroidBorder.enabled = true;
        whereToShowSnapshot.sprite = snapshotSprite;
        Debug.Log("Screenshot should show");
    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        snapshotPolaroidBorder.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
