using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("GameManager created and persists");
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"Game state changed to: {newState}");
		
		if (newState == GameState.Intro)
		{
			SceneManager.LoadScene("Intro Screen 1");
		}
		
		if (newState == GameState.Backstory)
		{
			SceneManager.LoadScene("Backstory start Screen");
		}
		
		if (newState == GameState.Meeting)
		{
			SceneManager.LoadScene("Meeting Screen");
		}
		
		if (newState == GameState.RoleIntroduction)
		{
			SceneManager.LoadScene("Environmentalist Intro Screen");
		}
		
		if (newState == GameState.People)
		{
			SceneManager.LoadScene("People Screen");
		}

    }
}