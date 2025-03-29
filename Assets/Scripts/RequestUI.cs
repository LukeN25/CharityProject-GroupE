using UnityEngine;
using TMPro;

public class RequestUI : MonoBehaviour
{
    public TextMeshProUGUI potatoCountText; 
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
