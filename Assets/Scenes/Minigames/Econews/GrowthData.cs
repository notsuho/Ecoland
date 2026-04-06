using UnityEngine;

public static class GrowthData
{
    public static int currentProgress = 0;
    public static int maxProgress = 5;
    public static int roryLifestage = 0;

    public static bool RewardAvailable
    {
        get { return currentProgress >= maxProgress; }
    }

    public static void MilestoneHit(int maxStage)
    {
        currentProgress = 0;
        if (roryLifestage < maxStage-1)
            roryLifestage++;
    }
}
