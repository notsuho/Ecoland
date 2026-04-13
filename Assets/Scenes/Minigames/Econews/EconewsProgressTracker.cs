using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EconewsProgressTracker : MonoBehaviour
{
    [Header("UI Reference")]
    public Image progressBarImage; 
    [Header("Progress Bar Sprites (0 → 5)")]
    public Sprite[] progressBarSprites;

    //public RoryLifeStage[] lifeStages;
    public Image roryImage;
    public RoryLifeStage roryLifeStageDatabase;
    public TMP_Text currentStage;
    public TMP_Text nextStage;
    public Button replayButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        GrowthData.currentProgress++;
        UpdateProgressBarUI();
        //UpdateRoryImageUI();
        replayButton.onClick.RemoveAllListeners();
        replayButton.onClick.AddListener(OnReplayClicked);
    }

    void OnReplayClicked()
    {
        if (GrowthData.RewardAvailable())
        {
            SceneManager.LoadScene("MinigameMenu");
        }
        else
        {
            SceneManager.LoadScene("EconewsListing");
        }
    }

    void UpdateProgressBarUI()
    {
        progressBarImage.sprite = progressBarSprites[GrowthData.currentProgress];
        int j = GrowthData.roryLifestage;
        // current stage
        var current = roryLifeStageDatabase.lifeStages[j];
        currentStage.text = current.stageName;

        // next stage (check if we are at the last stage)
        if (j < roryLifeStageDatabase.lifeStages.Count-1)
            nextStage.text = roryLifeStageDatabase.lifeStages[j + 1].stageName;
        else
            nextStage.text = "Fully Grown";
    }
    void UpdateRoryImageUI()
    {
        // current stage
        var current = roryLifeStageDatabase.lifeStages[GrowthData.roryLifestage];
        roryImage.sprite = current.rorySprite;
    }

}
