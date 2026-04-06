using UnityEngine;
using UnityEngine.UI;

public class GrowthManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Image progressBarImage; // Drag your UI Image here

    [Header("Progress Bar Sprites (0 → 5)")]
    public Sprite[] progressBarSprites; // Set size to 6 in Inspector

    public void UpdateProgress(int completedNews)
    {
        // Clamp value so it doesn't go out of bounds
        completedNews = Mathf.Clamp(completedNews, 0, progressBarSprites.Length - 1);

        // Swap the sprite
        progressBarImage.sprite = progressBarSprites[completedNews];
    }

    public int testValue;

    void Update()
    {
        UpdateProgress(testValue);
    }
}