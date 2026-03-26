using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageDialogueController : MonoBehaviour
{
    public GameObject[] textImages;    // Your text images
    public string nextSceneName;       // The scene to load after last image

    int index = 0;

    public void NextImage()
    {
        // If we have more images to show
        if (index < textImages.Length - 1)
        {
            textImages[index].SetActive(false);
            index++;
            textImages[index].SetActive(true);
        }
        else
        {
            // We are at the final image → load next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}