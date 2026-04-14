using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "DialogueObject", menuName = "Scriptable Objects/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    // For storing NPC dialogue to load for use in the dialoguebox text fields
    // Will see about supporting branching in future, keeping it simple for now

    [TextArea(10, 100)]
    public string[] dialogue;
    public bool needtoggle;
    public Sprite left;
    public Sprite right;

    public Choice[] choices;

    // Used if no choices (linear dialogue)
    public DialogueObject nextNode;
    public bool isChoice; // boolean flag for if this is a choice node
    public bool isLast; // boolean flag for if this is the last one in episode
    // Optional: scene transition
    public string sceneToLoad; // name of next scene to load after this dialogue node if needed

    [System.Serializable]
    public class Choice
    {
        public DialogueObject nextNode;
    }

}