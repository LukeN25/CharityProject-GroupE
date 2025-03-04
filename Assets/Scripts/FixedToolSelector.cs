
using UnityEngine;
using UnityEngine.UI;


public class FixedToolSelector : MonoBehaviour
{
    public enum ToolType { None, WateringCan, Shovel, Seeds }
    public ToolType currentTool = ToolType.None;

    [Header("Tool Slot UI Images")]
    public Image wateringCanSlot;  
    public Image shovelSlot;       
    public Image seedSlot;         

    [Header("UI Colors")]
    public Color highlightedColor = Color.yellow; 
    public Color normalColor = Color.white;       

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTool = ToolType.WateringCan;
            Debug.Log("Switched to WateringCan");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTool = ToolType.Shovel;
            Debug.Log("Switched to Shovel");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTool = ToolType.Seeds;
            Debug.Log("Switched to Seeds");
        }

        
        if (wateringCanSlot != null)
            wateringCanSlot.color = (currentTool == ToolType.WateringCan) ? highlightedColor : normalColor;
        if (shovelSlot != null)
            shovelSlot.color = (currentTool == ToolType.Shovel) ? highlightedColor : normalColor;
        if (seedSlot != null)
            seedSlot.color = (currentTool == ToolType.Seeds) ? highlightedColor : normalColor;
    }
}
