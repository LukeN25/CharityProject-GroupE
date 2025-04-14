using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public BirdCounterScript birdCounterScript;
    public string sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        if(birdCounterScript.birdsSnapshotted > 3 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad);
        } 
    }
}
