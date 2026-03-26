using UnityEngine;
using UnityEngine.UI;

public class PresetNameSpriteSwapper : MonoBehaviour
{
    [SerializeField] private Image nameBarImage; // the green bar Image
    [SerializeField] private Sprite barWithName; // the sprite that already contains the name
    private bool applied;

    // Hook this to NameBarButton → OnClick()
    public void ApplyPreset()
    {
        if (applied || nameBarImage == null || barWithName == null) return;
        nameBarImage.sprite = barWithName;
        applied = true;
    }
}