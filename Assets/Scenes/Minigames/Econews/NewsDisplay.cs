using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
Used by EconewsArticleView1 scene.
For displaying the news article chosen
in EconewsListing scene.
*/
public class NewsDisplay : MonoBehaviour
{
    /*
    Article text fields displayed in UI. Assigned in Unity editor
    */
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI categoryText;
    public TextMeshProUGUI descriptionText;
    public Button openLinkButton;
    private string currentLink;

    /*Displays chosen news article as scene starts*/
    void Start()
    {
        SetNews(SelectedNews.current);
    }

    /*Displays news article text and link as a button*/
    public void SetNews(NewsItem news)
    {
        titleText.text = news.title;
        dateText.text = "YLE NEWS " + FormatDate(news.pubDate);
        categoryText.text = "Categories: " + news.category;
        descriptionText.text = "Description: " + news.description;

        currentLink = news.link;

        openLinkButton.onClick.RemoveAllListeners();
        openLinkButton.onClick.AddListener(OpenLink);
    }

    /*Opens link when clicked*/
    void OpenLink()
    {
        Application.OpenURL(currentLink);
    }

    /*Formats displayed date*/
    string FormatDate(string rawDate)
    {
        try
        {
            DateTime parsedDate = DateTime.ParseExact(
                rawDate,
                "ddd, dd MMM yyyy HH:mm:ss zzz",
                CultureInfo.InvariantCulture
            );
            return parsedDate.ToString("ddd, dd MMM, yyyy", CultureInfo.GetCultureInfo("en-US"));
        }
        catch (Exception error)
        {
            Debug.LogError(error);
            return rawDate;
        }
    }
}
