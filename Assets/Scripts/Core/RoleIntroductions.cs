using UnityEngine;
using UnityEngine.SceneManagement;

public class RoleIntroductionController : MonoBehaviour
{
    private readonly string[] roleScenes =
    {
        "Environmentalist Intro Screen",
        "Financial Officer Intro Screen",
        "Security Chief Intro Screen"
    };

    public void LoadNextRole()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        for (int i = 0; i < roleScenes.Length; i++)
        {
            if (roleScenes[i] == currentScene)
            {
                // If this is NOT the last role, load the next one
                if (i < roleScenes.Length - 1)
                {
                    SceneManager.LoadScene(roleScenes[i + 1]);
                }
                else
                {
                    // Last role finished → return control to GameManager
                    GameManager.Instance.SetState(GameState.People);
                }

                return;
            }
        }

        Debug.LogError("Current scene is not part of the role intro sequence.");
    }
}