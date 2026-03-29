using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public GameObject rightPortrait;
    public GameObject leftPortrait;
    public GameObject dialogueBox;
    public GameObject choiceBox; //For storyline branching
    public DialogueObject lines;
    public int lineNumber = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the dialogueobject first line and display it in dialoguebox
        TextMeshProUGUI text = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        text.text = lines.dialogue[0].ToString();
        lineNumber++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLine()
    {
        //Called by the dialoguebox continue button on click
        //Updates dialoguebox dialog field with the next line
        //If there are no more lines, does nothing (for now)
        if (lineNumber < lines.dialogue.Length)
        {
        TextMeshProUGUI text = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        text.text = lines.dialogue[lineNumber];
        lineNumber++;
        }
        else
        {
            return;
        }
    }

    public void ToggleVisibility()
    {
        //WIP for toggling visibility of NPC avatars
    }
}
