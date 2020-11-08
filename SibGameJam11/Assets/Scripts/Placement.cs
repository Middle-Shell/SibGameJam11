using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject LightedBuilding;
    public GameObject DarkBuilding;

    private void Start()
    {
        TurnOffElectricity();
    }

    public void TurnOnElectricity()
    {
        LightedBuilding.SetActive(true);
        DarkBuilding.SetActive(false);
    }

    public void TurnOffElectricity()
    {
        LightedBuilding.SetActive(false);
        DarkBuilding.SetActive(true);
    }
}
