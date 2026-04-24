using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;

/*
Used by EconewsListing scene.
Uses RSS to fetch news articles.
Reads received XML data and saves news items.
*/
public class RssFetcher : MonoBehaviour
{
    //RSS url used to fetch wanted news
    //Note: if you see a corsproxy.io link in the url string below, remove it before future use
    //I am putting it there just so the demo build deplo will work, since webgl CORS is kind of a pain
    //But it is a pain for a good reason which is security! So yeah, this is hacky.
    //Even more reason to remove if you are only doing a normal build via Unity that spits out an .exe, no CORS problems there
    private string url = "https://yle.fi/rss/t/18-215534/en";
    public NewsListing newsListing;

    void Start()
    {
        StartCoroutine(GetRSS());
    }

    /*Fetching news through RSS*/
    IEnumerator GetRSS()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        //Checking for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error fetching RSS: " + request.error);
        }
        else
        {
            //Calls method after succesful request
            ParseRSS(request.downloadHandler.text);
        }
    }

    /*Reads XML data and lists news items*/
    void ParseRSS(string xmlData)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlData);

        XmlNodeList items = xmlDoc.GetElementsByTagName("item");

        List<NewsItem> newsList = new List<NewsItem>();

        //Adding all news items to newsList
        foreach (XmlNode item in items)
        {
            NewsItem news = new NewsItem();

            news.title = item["title"]?.InnerText;
            news.description = item["description"]?.InnerText;
            news.link = item["link"]?.InnerText;
            news.pubDate = item["pubDate"]?.InnerText;

            //handling multiple categories
            XmlNodeList categoryNodes = item.SelectNodes("category");
            //list for categories
            List<string> categories = new List<string>();
            //add all categories
            foreach (XmlNode node in categoryNodes)
            {
                categories.Add(node.InnerText);
            }

            news.category = string.Join(", ", categories);

            newsList.Add(news);
        }
        //call NewsListing to display news list
        newsListing.DisplayList(newsList);
    }
}