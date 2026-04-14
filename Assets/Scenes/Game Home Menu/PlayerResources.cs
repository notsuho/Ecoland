using TMPro;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private int money;
    private int workers;
    private int ecopoints;

    public static PlayerResources Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Reset();
    }

    public void Reset()
    {
        money = 100000000;
        workers = 250;
        ecopoints = 750;
    }

    public int GetMoney()
    {
        return money;
    }

    public int GetWorkers()
    {
        return workers;
    }

    public int GetEcopoints()
    {
        return ecopoints;
    }

    public void EditMoney(int amount)
    {
        money += amount;
    }

    public void EditWorkers(int amount)
    {
        workers += amount;
    }

    public void EditEcopoints(int amount)
    {
        ecopoints += amount;
    }

}
