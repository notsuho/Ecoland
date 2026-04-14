using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotatorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private Button button;
    [SerializeField]
    private float f;

    private IEnumerator coroutine;

    void Start()
    {
        button.interactable = false;
        coroutine = WaitAndSpin(obj, f);
        StartCoroutine(coroutine);

    }

    // Spins the specified object around the z-axis, object to spin assigned via serialized field in inspector
    // WaitTime controls wait time between "frames", adjust for overall desired speed and smoothness
    private IEnumerator WaitAndSpin(GameObject obj, float waitTime)
    {
        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(waitTime);
            obj.GetComponent<RectTransform>().Rotate(0.0f, 0.0f, -60.0f);
        }
        button.interactable = true;
    }
}