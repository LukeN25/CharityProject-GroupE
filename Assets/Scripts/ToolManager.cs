using UnityEngine;
using UnityEngine.UI;


public enum ToolType { None, WateringCan, Shovel }

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;
    public ToolType currentTool = ToolType.None;

    
    public Image wateringCanUIImage;
    public Image shovelUIImage;

    
    public Color highlightedColor = Color.yellow;
    public Color normalColor = Color.white;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
        SwitchTool(ToolType.WateringCan);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTool(ToolType.WateringCan);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTool(ToolType.Shovel);
        }
    }

    public void SwitchTool(ToolType tool)
    {
        currentTool = tool;
        UpdateToolUI();
    }

    void UpdateToolUI()
    {
        if (wateringCanUIImage != null && shovelUIImage != null)
        {
            if (currentTool == ToolType.WateringCan)
            {
                wateringCanUIImage.color = highlightedColor;
                shovelUIImage.color = normalColor;
            }
            else if (currentTool == ToolType.Shovel)
            {
                wateringCanUIImage.color = normalColor;
                shovelUIImage.color = highlightedColor;
            }
        }
    }
}
