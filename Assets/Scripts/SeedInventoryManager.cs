
using UnityEngine;
using UnityEngine.UI;


public class SeedInventoryManager : MonoBehaviour
{
    public static SeedInventoryManager Instance;

    public enum SeedType { None, Potato, Tomato }

    private SeedType currentSeed = SeedType.None;

    public Image seedSlotIcon;         
    public Sprite potatoSeedSprite;    
    public Sprite tomatoSeedSprite;   
    public Sprite emptySeedSprite;     

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PickUpSeed(SeedType seed)
    {
        currentSeed = seed;
        UpdateUI();
        Debug.Log("SeedInventoryManager: Picked up seed " + seed);
    }

    public void ClearSeed()
    {
        currentSeed = SeedType.None;
        UpdateUI();
    }

    public SeedType GetCurrentSeed() => currentSeed;

    public void UpdateUI()
    {
        if (seedSlotIcon != null)
        {
            seedSlotIcon.sprite = currentSeed switch
            {
                SeedType.Potato => potatoSeedSprite,
                SeedType.Tomato => tomatoSeedSprite,
                _ => emptySeedSprite,
            };
        }
    }
}
