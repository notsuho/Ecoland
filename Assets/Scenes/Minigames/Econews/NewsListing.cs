using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
Used by EconewsListing scene.
Generates buttons based on listed articles.
On button click, saves chosen article to static
SelectedNews NewsItem, 
and navigates to EconewsArticleView1 scene.
*/
public class NewsListing : MonoBehaviour
{
    //ScrollView Content
    public Transform contentParent;
    //Button prefab
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
            //Sets title text
            TextMeshProUGUI text = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            text.text = news.title;
            //Adds click listener
            Button newsButton = buttonObject.GetComponent<Button>();
            newsButton.onClick.AddListener(() => NewsClicked(news));
        }
    }

    /*Saves clicked article and loads article scene*/
    void NewsClicked(NewsItem news)
    {
        SelectedNews.current = news;
        //NAME MUST MATCH EXACT SCENE NAME
        SceneManager.LoadScene("EconewsArticleView1");
    }
}