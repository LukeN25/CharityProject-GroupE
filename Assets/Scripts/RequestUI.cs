using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RequestUI : MonoBehaviour
{
    [Header("Potato Request UI")]
    public Image potatoIcon;              
    public TextMeshProUGUI potatoCountText;  

    [Header("Tomato Request UI")]
    public Image tomatoIcon;              
    public TextMeshProUGUI tomatoCountText;  

    void Update()
    {
        if (TaskManager.Instance != null)
        {
            potatoCountText.text = $"{TaskManager.Instance.CollectedPotatoes}/{TaskManager.Instance.requiredPotatoes}";
            tomatoCountText.text = $"{TaskManager.Instance.CollectedTomatoes}/{TaskManager.Instance.requiredTomatoes}";
        }
    }
}
