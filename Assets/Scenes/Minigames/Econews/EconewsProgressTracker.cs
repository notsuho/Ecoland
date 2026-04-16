using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
UPDATES ANNOTATION PROGRESS
Used by EconewsEndScreen1 scene
Scene starts as player completes news annotation.
On start increases currentProgress in GrowthData by 1,
and updates the correct visual elements.
*/
public class EconewsProgressTracker : MonoBehaviour
{
    /*Variables visible and modifiable in
    Unity editor*/
    [Header("UI Reference")]
    public Image progressBarImage;
    [Header("Progress Bar Sprites (0 → 5)")]
    public Sprite[] progressBarSprites;
    public Image roryImage;
    public RoryLifeStage roryLifeStageDatabase;
    public TMP_Text currentStage;
    public TMP_Text nextStage;
    public Button replayButton;

    /*Updates static currentProgress variable in GrowthData, 
    and updates correct progressbar image to UI*/
    void Start()
    {
        GrowthData.currentProgress++;
        UpdateProgressBarUI();
        PlayerResources.Instance.EditEcopoints(250); 
        //UpdateRoryImageUI();
        replayButton.onClick.RemoveAllListeners();
        replayButton.onClick.AddListener(OnReplayClicked);
    }

    /*
    Econews replay button function implemeted here
    instead of unity editor to ensure correct progressing.
    Checks if reward is available (progress bar is full
    and rory is ready to age up)
    if true -> navigate to minigame menu to collect reward
    and reset progressbar
    if false -> navigate normally to Econews
    */
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

    /*Gets the correct progress bar sprite based on GrowthData.
    Array of sprites defined in unity editor.
    Updates displayed lifestage names at the ends
    of the progress bar.
    Lifestages also defined in Unity editor*/
    void UpdateProgressBarUI()
    {
        progressBarImage.sprite = progressBarSprites[GrowthData.currentProgress];
        int i = GrowthData.roryLifestage;
        //sets text for current stage
        var current = roryLifeStageDatabase.lifeStages[i];
        currentStage.text = current.stageName;

        //sets text for next stage (checks if we are at the last stage)
        if (i < roryLifeStageDatabase.lifeStages.Count - 1)
        {
            nextStage.text = roryLifeStageDatabase.lifeStages[i + 1].stageName;
        }
        else
        {
            nextStage.text = "Fully Grown";
        }
    }

    /*
    Can be used to update rory UI image based on life stage
    similarly to progressbar. 
    As of now, swapping of images is not implemented.
    Idea: for each lifestage item, an array of corresponding images,
    assigned in unity editor.
    Different scenes use different images, so the correct image
    would be chosen based on the current scene.
    Each scene could use a script to get the lifestage and choose
    the right image on start.
    */
    void UpdateRoryImageUI()
    {
        // current stage
        var current = roryLifeStageDatabase.lifeStages[GrowthData.roryLifestage];
        roryImage.sprite = current.rorySprite;
    }

}
