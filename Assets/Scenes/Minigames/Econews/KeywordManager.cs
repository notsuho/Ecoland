using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeywordManager : MonoBehaviour
{
    public GameObject keywordButtonPrefab;
    public Transform contentParent;    // GridLayoutGroup Content
    //light green
    public Color unselectedColor = new Color32(145, 215, 160, 255);
    //bright green
    public Color selectedColor = new Color32(58, 217, 92, 255);

    public KeywordDatabase keyDatabase;   // ScriptableObject with keywords

    private List<KeywordData> keywordList = new List<KeywordData>();

    void Start()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        LoadKeywords();
        GenerateButtons();
    }

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

    void GenerateButtons()
    {
        foreach (var keyword in keywordList)
        {
            GameObject buttonObject = Instantiate(keywordButtonPrefab, contentParent);

            //setting text
            TextMeshProUGUI label = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null)
                label.text = keyword.keyword;

            //getting button image for color change
            Image background = buttonObject.GetComponent<Image>();

            //adding click listener
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnKeywordClicked(keyword, background));
        }
    }

    void OnKeywordClicked(KeywordData keyword, Image background)
    {
        keyword.isSelected = !keyword.isSelected;
        if (keyword.isSelected)
            background.color = selectedColor;
        else
            background.color = unselectedColor;
            
    }
    //if a list of chosen keywords is needed
    public List<string> GetSelectedKeywords()
    {
        List<string> selected = new List<string>();
        foreach (var keyword in keywordList)
            if (keyword.isSelected) 
                selected.Add(keyword.keyword);
        return selected;
    }
}
