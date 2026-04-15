using System;
using UnityEngine;

public class PointUpdate : MonoBehaviour
{
    // For telling PlayerResources to update the ecopoints score for record keeping and UI display purposes
    public int amount = 250;

    void Start()
    {
       // Just run update at the start of the scene
       // A bit hacky, but for now should work
       PlayerResources.Instance.EditEcopoints(amount); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
