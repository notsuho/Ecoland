using UnityEngine;

public class ShowIconAfterDelay : MonoBehaviour
{
    public GameObject icon;      // Drag your icon here
    public float delay = 2f;     // Seconds before showing it

    void Start()
    {
        StartCoroutine(Show());
    }

    private System.Collections.IEnumerator Show()
    {
        yield return new WaitForSeconds(delay);
        icon.SetActive(true);
    }
}