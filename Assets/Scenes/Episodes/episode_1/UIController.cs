using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public DialogueController dg;
    public GameObject rightPortrait;
    public GameObject leftPortrait;
    public GameObject rewardButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleVisibility(GameObject obj)
    {
        //Toggles visibility of elements
        //Just a simple implementation for
        //now, sets status to opposite of
        //current (i.e. if on --> off etc.)
   
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }

    }

    /**public void LoadLeftPortrait(Sprite img)
    {
       leftPortrait.GetComponent<Image>().sprite = img;
    }

        public void LoadRightPortrait(Sprite img)
    {
       leftPortrait.GetComponent<Image>().sprite = img;
    }**/

    public void DisplayRewardButton()
    {
        ToggleVisibility(rewardButton);
    }

    /**public void SpinElement(GameObject obj)
    {
        for (int i = 0; i<4; i++) {
        obj.GetComponent<RectTransform>().Rotate(0.0f, 0.0f, 30.0f);
        }
    }**/
}
