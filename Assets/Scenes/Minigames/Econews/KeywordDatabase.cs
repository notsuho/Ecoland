using System.Collections.Generic;
using UnityEngine;

/*
Keyword Database asset in Unity editor to store
and modify keywords.
List of keywords.
Used by KeywordManager.
*/

/*Menu and filename visible in Unity editor*/
[CreateAssetMenu(fileName = "KeywordDatabase", menuName = "Scriptable Objects/KeywordDatabase")]
public class KeywordDatabase : ScriptableObject
{
    public List<string> keywords;
}
