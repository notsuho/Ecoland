using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*Displaying news article in article view scene*/
public class NewsDisplay : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI categoryText;
    public TextMeshProUGUI descriptionText;
    public Button openLinkButton;

    private string currentLink;
    /*Getting clicked news article as scene starts*/
    void Start()
    {
        SetNews(SelectedNews.current);
    }

    /*Displays news article text and link as a button*/
    public void SetNews(NewsItem news)
    {
        titleText.text = news.title;
        dateText.text = news.pubDate;
        categoryText.text = news.category;
        descriptionText.text = news.description;

        currentLink = news.link;

        openLinkButton.onClick.RemoveAllListeners();
        openLinkButton.onClick.AddListener(OpenLink);
    }

    void OpenLink()
    {
        Application.OpenURL(currentLink);
    }
}
