using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrowthManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Image progressBarImage; 
    public Button chestButton;

    [Header("Progress Bar Sprites (0 → 5)")]
    public Sprite[] progressBarSprites; // Set size to 6 in Inspector

    //public RoryLifeStage[] lifeStages;
    public Image roryImage;
    public RoryLifeStage roryLifeStageDatabase;
    public TMP_Text currentStage;
    public TMP_Text nextStage;

    void Start()
    {
        chestButton.onClick.RemoveAllListeners();
        chestButton.onClick.AddListener(OnChestClicked);

        UpdateProgress(GrowthData.currentProgress);
    }

    public void UpdateProgress(int completedNews)
    {
        // Clamp value so it doesn't go out of bounds
        completedNews = Mathf.Clamp(completedNews, 0, progressBarSprites.Length - 1);
        GrowthData.currentProgress = completedNews;
        // Swap the sprite
        progressBarImage.sprite = progressBarSprites[completedNews];
        chestButton.interactable = GrowthData.RewardAvailable;
    }

    void OnChestClicked()
    {
        if (GrowthData.RewardAvailable)
        {
            Debug.Log("Player got a reward!");

            GrowthData.MilestoneHit(roryLifeStageDatabase.lifeStages.Count);

            UpdateProgress(GrowthData.currentProgress);
            UpdateStageUI();
        }
        else
        {
            return;
        }
    }

    void UpdateStageUI()
    {
        int i = GrowthData.roryLifestage;
        // current stage
        var current = roryLifeStageDatabase.lifeStages[i];
        currentStage.text = current.stageName;
        //roryImage.sprite = current.rorySprite;

        // next stage (check if we are at the last stage)
        if (i < roryLifeStageDatabase.lifeStages.Count-1)
            nextStage.text = roryLifeStageDatabase.lifeStages[i + 1].stageName;
        else
            nextStage.text = "Fully Grown";
    }

    public int testValue;

    void Update()
    {
        UpdateProgress(testValue);
    }
}