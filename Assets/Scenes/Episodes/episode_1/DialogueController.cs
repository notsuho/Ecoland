using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    public SceneController sc;
    public UIController uc;
    public GameObject dialogueBox;
    public GameObject choiceBox; // For storyline branching
    public DialogueObject current; // For tracking the current dialogue object node
    private int lineNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Starts dialogue from the dialogue object node given as argument
    // Displays initial line of dialogue in dialogue box
    public void StartDialogue(DialogueObject obj)
    {
        lineNumber = 0;

        current = obj;
        //Get the dialogueobject first line and display it in dialoguebox
        TextMeshProUGUI text = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        if (current != null)
        {
            text.text = current.dialogue[0].ToString();
            lineNumber++;
        }
    }

    public void NextDialogue()
    {
        if (current.nextNode != null)
        {
            current = current.nextNode;
            lineNumber = 0;
            Debug.Log("At start of NextDialogue(), dialogueobject: " + current.ToString());
            if (current.isChoice)
            {
                DisplayChoice();
                NextLine(current.needtoggle);
            }
            else
            {
                uc.leftPortrait.GetComponent<Image>().sprite = current.left;
                uc.rightPortrait.GetComponent<Image>().sprite = current.right;
                NextLine(current.needtoggle);
            }
        }
    }

    public void NextLine(bool needtoggle)
    {
        // Called by the dialoguebox continue button on click
        // Updates dialoguebox dialog field with the next line
        // If there are no more current, loads the next dialogue object if available
        // Debug.Log("At start of NextLine(), current.dialogue.length is " + current.dialogue.Length);
        // Debug.Log("At start of NextLine(), lineNumber is " + lineNumber);

        // check to see if we are at the end of the current dialogue object's array of dialogue lines
        // load and display the lines in dialoguebox if we aren't
        Debug.Log("At start of NextLine(), dialogueobject: " + current.ToString());
        if (lineNumber < current.dialogue.Length)
        {
            TextMeshProUGUI text = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
            text.text = current.dialogue[lineNumber];
            lineNumber++;
            if (needtoggle)
            {
                // if we have two speaker, toggle their avatars on/off alternating
                // to indicate who is talking; a bit janky tbh but works for now
                PortraitToggle();
            }
        }
        else
        {
            // we are at the end, and the next node needs a new scene to load
            // if there is nothing in the field, all good no need to do anything
            // otherwise load that scene
            if (!string.IsNullOrEmpty(current.sceneToLoad))
            {
                sc.LoadScene(current.sceneToLoad);
            }
            // if we are at the end and need to dislpay the reward button
            if (current.isLast && current.nextNode == null && lineNumber <= current.dialogue.Length)
            {
                uc.DisplayRewardButton();
            }
            else 
            {
                // otherwise just load the next dialogue node as normal
                NextDialogue();
            }
        }
    }

    public void DisplayChoice()
    {
        choiceBox.GetComponentInChildren<TextMeshProUGUI>().SetText(current.dialogue[0].ToString());
        uc.ToggleVisibility(dialogueBox);
        uc.ToggleVisibility(choiceBox);
        uc.ToggleVisibility(uc.leftPortrait);
    }

    public void PortraitToggle()
    {
        uc.ToggleVisibility(uc.rightPortrait);
        uc.ToggleVisibility(uc.leftPortrait);  
    }

}
