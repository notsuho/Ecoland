using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;

public class RssFetcher : MonoBehaviour
{
    //RSS url used to fetch wanted news
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
            //calling method after succesful request
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
