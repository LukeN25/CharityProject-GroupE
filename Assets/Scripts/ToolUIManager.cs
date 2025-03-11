using UnityEngine;
using UnityEngine.UI;


public class ToolUIManager : MonoBehaviour
{
    public Image wateringCanIcon;
    public Image shovelIcon;
    public Image seedIcon;
    public Color highlightColor = Color.yellow;
    public Color defaultColor = Color.white;

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        wateringCanIcon.color = defaultColor;
        shovelIcon.color = defaultColor;
        seedIcon.color = defaultColor;

        ToolManager.ToolType currentTool = ToolManager.Instance.GetCurrentTool();

        if (currentTool == ToolManager.ToolType.WateringCan) wateringCanIcon.color = highlightColor;
        if (currentTool == ToolManager.ToolType.Shovel) shovelIcon.color = highlightColor;
        if (currentTool == ToolManager.ToolType.Seed) seedIcon.color = highlightColor;
    }
}
