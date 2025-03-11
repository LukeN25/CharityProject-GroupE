using UnityEngine;
using UnityEngine.UI;


public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;

    public enum ToolType { None, WateringCan, Shovel, Seed }
    public enum SeedType { None, Potato, Tomato }

    private ToolType currentTool = ToolType.None;
    private SeedType currentSeed = SeedType.None;

    public Image wateringCanIcon;
    public Image shovelIcon;
    public Image seedIcon;
    public Sprite potatoSeedSprite;
    public Sprite tomatoSeedSprite;
    public Sprite emptySeedSprite;
    public Color highlightColor = Color.yellow;
    public Color defaultColor = Color.white;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        UpdateToolUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectTool(ToolType.WateringCan);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectTool(ToolType.Shovel);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectTool(ToolType.Seed);
    }

    public void SelectTool(ToolType tool)
    {
        currentTool = tool;
        UpdateToolUI();
    }

    public void PickUpSeed(SeedType seed)
    {
        currentSeed = seed;
        SelectTool(ToolType.Seed);
        UpdateToolUI();
    }

    private void UpdateToolUI()
    {
        wateringCanIcon.color = defaultColor;
        shovelIcon.color = defaultColor;
        seedIcon.color = defaultColor;

        if (currentTool == ToolType.WateringCan) wateringCanIcon.color = highlightColor;
        if (currentTool == ToolType.Shovel) shovelIcon.color = highlightColor;
        if (currentTool == ToolType.Seed) seedIcon.color = highlightColor;

        seedIcon.sprite = currentSeed switch
        {
            SeedType.Potato => potatoSeedSprite,
            SeedType.Tomato => tomatoSeedSprite,
            _ => emptySeedSprite
        };
    }

    public ToolType GetCurrentTool() => currentTool;
    public SeedType GetCurrentSeed() => currentSeed;
}
