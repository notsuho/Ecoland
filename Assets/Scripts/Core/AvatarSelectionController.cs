using UnityEngine;

public class AvatarSelectionController : MonoBehaviour
{
    [Header("Avatar visuals")]
    public GameObject[] selectionRings;
    public GameObject handPointer;

    [Header("Navigation")]
    public GameObject nextButton;

    
	public void SelectAvatar(int index)
	{
    if (selectionRings == null || selectionRings.Length == 0)
    {
        Debug.LogError("selectionRings not assigned");
        return;
    }

    for (int i = 0; i < selectionRings.Length; i++)
        selectionRings[i].SetActive(i == index);

    if (handPointer != null)
        handPointer.SetActive(false);
    else
        Debug.LogError("handPointer is null");

    if (nextButton != null)
        nextButton.SetActive(true);
    else
        Debug.LogError("nextButton is null");

    if (PlayerManager.Instance != null)
        PlayerManager.Instance.AvatarIndex = index;
    else
        Debug.LogError("PlayerManager.Instance is null");

    if (GameManager.Instance != null)
        GameManager.Instance.SetState(GameState.AvatarSelection);
    else
        Debug.LogError("GameManager.Instance is null");

    Debug.Log($"Avatar {index} selected");
	}

	public void OnNextPressed()
	{
    
		GameManager.Instance.SetState(GameState.Backstory);
    
	}

}