using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterAdv : MonoBehaviour
{

	public GameObject Prefabs; 
	private GameObject Advertisment;

	private GameManager gameManager;

    void Start()
    {
    	gameManager = FindObjectOfType<GameManager>();
        AddInfo();
    }

    public void UpdateInfo()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        AddInfo();
    }

    private void AddInfo()
    {
        for (int i = 0; i < gameManager.autoGenerators.Length; i++)
        {
            Advertisment = Instantiate(Prefabs, new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
            Advertisment.GetComponent<ButtonWorker>().Title.text = gameManager.autoGenerators[i].TypeOfGenerator;
            Advertisment.GetComponent<ButtonWorker>().GeneratorType = gameManager.autoGenerators[i].TypeOfGenerator;
            Advertisment.GetComponent<ButtonWorker>().PricePerformance.text =  $"Стоимость: {gameManager.autoGenerators[i].CostOfOne} Эл."
                + $"\n{gameManager.autoGenerators[i].DefaultElectricityPerMoment}"
                + " Эл/сек\n"
                + $"Колличество: {gameManager.autoGenerators[i].NumOfGenerators}";
        }
    }


}
