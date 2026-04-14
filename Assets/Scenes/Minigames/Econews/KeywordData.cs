using UnityEngine;

/*
Data structure for each Keyword item in KeywordDatabase (list)
Keyword strings assigned in Unity editor through KeywordDatabase asset.
Used by KeywordManager.
*/

[System.Serializable]
public class KeywordData
{
    public string keyword;
    public bool isSelected;
}
