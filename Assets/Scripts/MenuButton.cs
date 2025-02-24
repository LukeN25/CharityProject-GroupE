using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
   
    public string sceneToLoad;
    
    public float scaleFactor = 1.1f;

    private Vector3 originalScale;

    void Start()
    {
       
        originalScale = transform.localScale;
    }

   
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * scaleFactor;
    }

    
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        
        SceneManager.LoadScene(sceneToLoad);
    }
}
