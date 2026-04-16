using UnityEngine;

public class WelcomeController : MonoBehaviour
{
    public void OnStartPressed()
    {
        GameManager.Instance.SetState(GameState.Intro);
    }
}