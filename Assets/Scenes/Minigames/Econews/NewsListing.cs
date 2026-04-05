using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NewsListing : MonoBehaviour
{
    //ScrollView Content
    public Transform contentParent;
    // Button prefab
    public GameObject buttonPrefab;

    /*Displays news in UI as a button list*/
    public void DisplayList(List<NewsItem> newsList)
    {
        //Clear old buttons if reloading
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        //Create buttons with article titles
        foreach (NewsItem news in newsList)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, contentParent);

            //Set title text
            TextMeshProUGUI text = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            text.text = news.title;

            //Add click listener
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnNewsClicked(news));
        }
    }

    /*saves clicked article and loads article scene*/
    void OnNewsClicked(NewsItem news)
    {
        SelectedNews.current = news;
        //Load article scene with chosen article
        //NAME MUST MATCH EXACT SCENE NAME
        SceneManager.LoadScene("EconewsArticleView1");
    }
}