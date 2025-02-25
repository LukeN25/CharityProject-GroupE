using UnityEngine;

public enum ToolType { None, WateringCan, Shovel }

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;
    public ToolType currentTool = ToolType.None;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
}
