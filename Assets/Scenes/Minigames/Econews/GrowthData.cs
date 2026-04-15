using UnityEngine;

/*
Stores progress and lifestage data. 
Can be read and modified across scenes.
EconewsProgressTracker increases currentProgress.
GrowthManager calls MilestoneHit()
*/
public static class GrowthData
{
    /*progress from lifestage to another, used with progressbar*/
    public static int currentProgress = 0;
    /*Max progress before increasing roryLifestage
    and resetting currentProgress*/
    public static int maxProgress = 5;
    /*Tracks current lifestage*/
    public static int roryLifestage = 0;

    /*Checks if reward chest is available
    (progress bar is full)
    Called by GrowthManager*/
    public static bool RewardAvailable()
    {
        return currentProgress >= maxProgress;
    }

    /*Called by GrowthManager when reward chest is clicked.
    Resets progress and increases lifestage.
    Parameter maxStage = max number of lifestages assigned
    in Unity editor*/
    public static void MilestoneHit(int maxStage)
    {
        currentProgress = 0;
        if (roryLifestage < maxStage - 1)
        {
            roryLifestage++;
        }
    }
}
