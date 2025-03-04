using UnityEngine;
using UnityEngine.UI;


public class ToolUIManager : MonoBehaviour
{
    [Header("Tool Slot UI Images")]
    public Image wateringCanSlot;
    public Image shovelSlot;
    public Image seedSlot; 

    [Header("Seed Slot Icons")]
    public Sprite defaultSeedIcon;   
    public Sprite potatoSeedIcon;    
    public Sprite tomatoSeedIcon;    

    [Header("Highlight Colors")]
    public Color highlightedColor = Color.yellow;
    public Color normalColor = Color.white;

    void Update()
    {
        if (ToolManager.Instance == null)
            return;

       
        ToolManager.ToolType currentTool = ToolManager.Instance.currentTool;

        
        wateringCanSlot.color = (currentTool == ToolManager.ToolType.WateringCan) ? highlightedColor : normalColor;
        shovelSlot.color = (currentTool == ToolManager.ToolType.Shovel) ? highlightedColor : normalColor;
        seedSlot.color = (currentTool == ToolManager.ToolType.Seeds) ? highlightedColor : normalColor;

        
        ToolManager.SeedType heldSeed = ToolManager.Instance.heldSeed;
        switch (heldSeed)
        {
            case ToolManager.SeedType.Potato:
                seedSlot.sprite = potatoSeedIcon;
                break;
            case ToolManager.SeedType.Tomato:
                seedSlot.sprite = tomatoSeedIcon;
                break;
            default:
                seedSlot.sprite = defaultSeedIcon;
                break;
        }
    }
}
