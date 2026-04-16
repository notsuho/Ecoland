using UnityEngine;

public class MeetingController : MonoBehaviour
{
    public void OnContinuePressed()
    {
        GameManager.Instance.SetState(GameState.RoleIntroduction);
    }
}