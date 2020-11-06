using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Generator[] generators;
    [Space]
	public float Electricity = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var generator in generators)
        {
            Electricity += generator.NumberOfGenerators * generator.ElectricityPerMoment;
        }

        print(Mathf.FloorToInt(Electricity));
    }

    public void DebuffGeneratorOfType(string type, float debuffTime) 
    {
        StartCoroutine(type, debuffTime);
    }


    private IEnumerator DebuffTime(string type, float debuffTime)
    {
        Generator element = GetElementByType(type);
        float defaultElectricity = element.ElectricityPerMoment;

        element.ElectricityPerMoment /= 2;

        yield return new WaitForSeconds(debuffTime);

        element.ElectricityPerMoment = defaultElectricity;
    }

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
}

[System.Serializable]
class Generator
{
    public string GeneratorType;
    public int NumberOfGenerators;
    public bool IsWorking = true;
    public float ElectricityPerMoment = 1;
}