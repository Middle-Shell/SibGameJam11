using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerator : MonoBehaviour
{
    public string NameOfGeneratorType;
    public int NumOfGenerators; //цена
    public int CostOfOne; //цена
    public float DefaultElectricityPerMoment = 1; //значение увелечения
    [HideInInspector]public float CurrentElectricityPerMoment = 1;
    public bool IsWorking = true;

    private bool IsBuffed = false;

    private void Start()
    {
        CurrentElectricityPerMoment = DefaultElectricityPerMoment;
    }

    public void Buff()
    {
        if (!IsBuffed)
        {
            IsBuffed = true;
            CurrentElectricityPerMoment = DefaultElectricityPerMoment * 2;
        }
    }

    IEnumerator RemoveBuff()
    {
        yield return new WaitForSeconds(.5f);

        IsBuffed = false;
        CurrentElectricityPerMoment = DefaultElectricityPerMoment;
    }
}