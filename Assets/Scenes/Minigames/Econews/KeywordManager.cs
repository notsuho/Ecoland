using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Used by EconewsArticleView1 scene.
Displays keywords in UI and manages selection.
*/
public class KeywordManager : MonoBehaviour
{
    /*Assigned in Unity editor*/
    public GameObject keywordButtonPrefab;
    public Transform contentParent; //GridLayoutGroup content
    public KeywordDatabase keyDatabase; //ScriptableObject with keywords
    private List<KeywordData> keywordList = new List<KeywordData>();

    /*Colors for keyword buttons*/
    public Color unselectedColor = new Color32(145, 215, 160, 255); //light green
    public Color selectedColor = new Color32(58, 217, 92, 255); //bright green

    /*Clears old buttons and placeholders.
    Calls to load keywords and generate new buttons*/
    void Start()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        LoadKeywords();
        GenerateButtons();
    }

    /*
    Clears keywordList.
    Gets keywords and sets selection to false.
    Adds keywordData to list.
    */
    void LoadKeywords()
    {
        keywordList.Clear();
        foreach (var key in keyDatabase.keywords)
        {
            KeywordData keywordData = new KeywordData
            {
                keyword = key,
                isSelected = false
            };
            keywordList.Add(keywordData);
        }
    }

    /*
    Generates keyword buttons with the selected button prefab in Unity.
    */
    void GenerateButtons()
    {
        foreach (var keyword in keywordList)
        {
            GameObject buttonObject = Instantiate(keywordButtonPrefab, contentParent);
            //setting text
            TextMeshProUGUI label = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null)
            {
                label.text = keyword.keyword;
            }

            //gets button image for color change
            Image background = buttonObject.GetComponent<Image>();

            //adds click listener
            Button keyButton = buttonObject.GetComponent<Button>();
            keyButton.onClick.AddListener(() => KeywordClicked(keyword, background));
        }
    }

    /*
    Records keyword selection on click.
    Changes UI button color to indicate selection.
    */
    void KeywordClicked(KeywordData keyword, Image background)
    {
        keyword.isSelected = !keyword.isSelected;
        if (keyword.isSelected)
        {
            background.color = selectedColor;
        }
        else
        {
            background.color = unselectedColor;
        }
        //var testingSelectedList = GetSelectedKeywords();
    }

    /*Method for listing selected keywords if needed*/
    public List<string> GetSelectedKeywords()
    {
        List<string> selected = new List<string>();
        foreach (var keyword in keywordList)
        {
            if (keyword.isSelected)
            {
                selected.Add(keyword.keyword);
            }
        }
        Debug.Log(string.Join(", ", selected));
        return selected;
    }
}