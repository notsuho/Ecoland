using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public GameObject rightPortrait;
    public GameObject leftPortrait;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleVisibility()
    {
        //WIP for toggling visibility of NPC avatars
        if (rightPortrait.activeSelf && leftPortrait.activeSelf)
        {
            rightPortrait.SetActive(false);
            leftPortrait.SetActive(false);
        }
        else
        {
            rightPortrait.SetActive(true);
            leftPortrait.SetActive(true);
        }
        
    }

    public void LoadBranch(GameObject button)
    {
        //Called by the on click method attached to the branch choice buttons.
        //Receives as argument which button was pressed, so we can then
        //decide which next story branch scene to load based on the choice.
        Debug.Log(button.name.ToString() + " was pressed.");

        switch (button.name.ToString())
        {
            case "Left Choice":
            SceneManager.LoadScene("episode_1_choice_1");
            break;
            case "Right Choice":
            SceneManager.LoadScene("episode_1_choice_2");
            break;
            default:
            Debug.Log("Default choice, nothing will happen.");
            break;
        }

    }
}
