using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Used by MinigameMenu scene.
Controls reward chest button.
Updates UI progress bar image and text.
Calls GrowthData.MilestoneHit() to reset progress and increase lifestage.
*/
public class GrowthManager : MonoBehaviour
{
    /*Variables visible and modifiable in
    Unity editor*/
    [Header("UI Reference")]
    public Image progressBarImage;
    public Button chestButton;
    public Button startButton;

    [Header("Progress Bar Sprites (0 → 5)")]
    public Sprite[] progressBarSprites;
    /*image swapping not implemented yet*/
    //public Image roryImage;
    public RoryLifeStage roryLifeStageDatabase;
    public TMP_Text currentStage;
    public TMP_Text nextStage;

    /*Adds listener to chestbutton.
    Calls UpdateProgress()*/
    void Start()
    {
        chestButton.onClick.RemoveAllListeners();
        chestButton.onClick.AddListener(ChestClicked);

        UpdateProgress();
    }

    /*
    Updates UI elements.
    Disables/enables chest and start buttons based on
    reward availability (boolean value)
    Called at start and by ChestClicked()
    */
    void UpdateProgress()
    {
        UpdateProgressBarUI();
        /*Enables chestButton when reward is available*/
        chestButton.interactable = GrowthData.RewardAvailable();
        /*Disables startButton when reward is available*/
        startButton.interactable = !GrowthData.RewardAvailable();
    }

    /*Checks if reward is available.
    Calls GrowthData.MilestoneHit() to reset progress
    and increase lifeStage, with the max number of
    lifestages based on database asset "roryLifeStageDatabase", 
    modifiable in Unity*/
    void ChestClicked()
    {
        /*If reward is available/chest is clickable*/
        if (GrowthData.RewardAvailable())
        {
            /*A reward system can be implemented
            and called here. Such as gaining ecopoints.*/
            PlayerResources.Instance.EditEcopoints(250); 
            Debug.Log("Player got 250 ecopoints!");
            /*Reset progress and grow Rory*/
            GrowthData.MilestoneHit(roryLifeStageDatabase.lifeStages.Count);
            /*Update UI and chest availability*/
            UpdateProgress();
        }
        else
        {
            return;
        }
    }

    /*Gets the correct progress bar sprite based on GrowthData.
    Array of sprites defined in unity editor.
    Updates displayed lifestage names at the ends
    of the progress bar.
    Lifestages defined in Unity editor*/
    void UpdateProgressBarUI()
    {
        progressBarImage.sprite = progressBarSprites[GrowthData.currentProgress];
        int j = GrowthData.roryLifestage;
        //sets text for current stage
        var current = roryLifeStageDatabase.lifeStages[j];
        currentStage.text = current.stageName;

        //sets text for next stage (checks if we are at the last stage)
        if (j < roryLifeStageDatabase.lifeStages.Count - 1)
        {
            nextStage.text = roryLifeStageDatabase.lifeStages[j + 1].stageName;
        }
        else
        {
            nextStage.text = "Fully Grown";
        }
    }
}