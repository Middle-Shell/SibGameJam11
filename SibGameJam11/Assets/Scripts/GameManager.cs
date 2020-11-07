using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float Electricity = 0;
    [HideInInspector] public float ElectricityInTotal;
    [Space]

    public AutoGenerator[] autoGenerators;
    [Space]
    public AutoGenerator ActiveGenerator = null;

    private AutoGenerator GetElementByType(string type)
    {
        AutoGenerator elementOfType = null;

        foreach (var generatorType in autoGenerators)
        {
            if (generatorType.NameOfGeneratorType == type)
            {
                elementOfType = generatorType;
            }
        }

        return elementOfType;
    }

    void Update()
    {
        foreach (var generator in autoGenerators)
        {
            ElectricityInTotal += generator.NumOfGenerators * generator.CurrentElectricityPerMoment * Time.deltaTime;
            Electricity += generator.NumOfGenerators * generator.CurrentElectricityPerMoment * Time.deltaTime;
        }
    }

    #region Debuff:

    public void DebuffGeneratorOfType(string type, float debuffTime)
    {
        StartCoroutine(DebuffTime(type, debuffTime));
    }

    private IEnumerator DebuffTime(string type, float debuffTime)
    {
        AutoGenerator element = GetElementByType(type);

        element.CurrentElectricityPerMoment /= 2;

        yield return new WaitForSeconds(debuffTime);

        element.CurrentElectricityPerMoment = element.DefaultElectricityPerMoment;
    }

    #endregion
}