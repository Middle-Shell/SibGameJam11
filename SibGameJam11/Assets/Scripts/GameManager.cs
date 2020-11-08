using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float Electricity = 0;
    /*[HideInInspector] */public float ElectricityInTotal;
    [Space]

    public Transform HandGenerators;
    [Space]

    public AutoGenerator[] autoGenerators;
    [Space]
    public AutoGenerator ActiveGenerator = null;

    public AutoGenerator GetGeneratorByType(string type)
    {
        AutoGenerator elementOfType = null;

        foreach (var generatorType in autoGenerators)
        {
            if (generatorType.TypeOfGenerator == type)
            {
                elementOfType = generatorType;
            }
        }

        return elementOfType;
    }

    private void Start()
    {
        ElectricityInTotal = Electricity;
    }

    void Update()
    {
        foreach (var generatorType in autoGenerators)
        {
            if (generatorType.IsWorking)
            {
                ElectricityInTotal += generatorType.NumOfGenerators * generatorType.CurrentElectricityPerMoment * Time.deltaTime;
                Electricity += generatorType.NumOfGenerators * generatorType.CurrentElectricityPerMoment * Time.deltaTime;
            }
        }
    }

    public void HandGeneratorUpgrade(GameObject currentGenerator)
    {
        foreach (Transform generator in HandGenerators)
        {
            generator.gameObject.SetActive(false);
        }

        currentGenerator.SetActive(true);
    }

    public void DebuffGeneratorsByTypes(float debuffTime)
    {
        foreach (var generator in autoGenerators)
        {
            generator.Debuff(debuffTime);
        }
    }
    public void TurnOffGeneratorsByTypes(string[] types, float debuffTime)
    {
        foreach (var type in types)
        {
            GetGeneratorByType(type).TurnOff(debuffTime);
        }
    }
    public void SubstractElectricity(float substractNum)
    {
        Electricity -= substractNum;
    }
}