using UnityEngine;

public class BackstoryController : MonoBehaviour
{
    public void OnContinuePressed()
    {
        GameManager.Instance.SetState(GameState.Meeting);
    }
}