using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float Electricity = 0;
    [HideInInspector] public float ElectricityInTotal;
    [Space]

    [SerializeField] public Generator[] generators;
    private Generator GetElementByType(string type)
    {
        Generator elementOfType = null;

        foreach (var generatorType in generators)
        {
            if (generatorType.GeneratorType == type)
            {
                elementOfType = generatorType;
            }
        }

        return elementOfType;
    }

    void Update()
    {
        foreach (var generator in generators)
        {
            ElectricityInTotal += generator.NumberOfGenerators * generator.ElectricityPerMoment * Time.deltaTime;
            Electricity += generator.NumberOfGenerators * generator.ElectricityPerMoment * Time.deltaTime;
        }

        //print(Mathf.FloorToInt(Electricity));
    }

    #region Debuff:

    public void DebuffGeneratorOfType(string type, float debuffTime)
    {
        StartCoroutine(DebuffTime(type, debuffTime));
    }

    private IEnumerator DebuffTime(string type, float debuffTime)
    {
        Generator element = GetElementByType(type);
        float defaultElectricity = element.ElectricityPerMoment;

        element.ElectricityPerMoment /= 2;

        yield return new WaitForSeconds(debuffTime);

        element.ElectricityPerMoment = defaultElectricity;
    }

    #endregion
}

[System.Serializable]
public class Generator
{
    public string GeneratorType;
    public int NumberOfGenerators;
    public bool IsWorking = true;
    public float ElectricityPerMoment = 1;
}