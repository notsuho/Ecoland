using TMPro;
using UnityEngine;

public class ResourceUpdater : MonoBehaviour
{
    public GameObject money;
    public GameObject workers;
    public GameObject ecopoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      money.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PlayerResources.Instance.GetMoney().ToString();
      workers.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PlayerResources.Instance.GetWorkers().ToString();
      ecopoints.GetComponentInChildren<TextMeshProUGUI>().text = PlayerResources.Instance.GetEcopoints().ToString();
    }

    public void UpdateMoney(int i)
    {
        PlayerResources.Instance.EditMoney(i);
    }

    public void UpdateWorkers(int i)
    {
        PlayerResources.Instance.EditWorkers(i);
    }

    public void UpdateEcopoints(int i)
    {
        PlayerResources.Instance.EditEcopoints(i);
    }
}
