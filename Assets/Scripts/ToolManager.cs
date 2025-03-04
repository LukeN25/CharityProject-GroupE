
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;

    public enum ToolType { None, WateringCan, Shovel, Seeds }
    public enum SeedType { None, Potato, Tomato }

    public ToolType currentTool = ToolType.None;
    public SeedType heldSeed = SeedType.None;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTool = ToolType.WateringCan;
            Debug.Log("ToolManager: Switched to WateringCan");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTool = ToolType.Shovel;
            Debug.Log("ToolManager: Switched to Shovel");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTool = ToolType.Seeds;
            Debug.Log("ToolManager: Switched to Seeds");
        }
    }
}
