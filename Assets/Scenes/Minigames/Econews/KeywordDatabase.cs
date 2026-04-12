using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeywordDatabase", menuName = "Scriptable Objects/KeywordDatabase")]
public class KeywordDatabase : ScriptableObject
{
    public List<string> keywords;
}
