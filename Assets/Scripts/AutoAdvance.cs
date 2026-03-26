using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoAdvance : MonoBehaviour
{
    [SerializeField] private float delaySeconds = 2.0f;
    [SerializeField] private string nextSceneName = "NextScene"; // exact scene name

    private void Start()
    {
        // Start a delayed load
        Invoke(nameof(LoadNext), delaySeconds);
    }

    private void LoadNext()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("[AutoAdvance] nextSceneName is empty.");
        }
    }
}