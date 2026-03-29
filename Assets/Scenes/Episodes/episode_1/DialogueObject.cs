using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObject", menuName = "Scriptable Objects/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    //For storing NPC dialogue to load for use in the dialoguebox text fields
    //Will see about supporting branching in future, keeping it simple for now

    [TextArea(10, 100)]
    public string[] dialogue;

}