using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

	private GameManager gameManager;
	private GameObject handGanerator;
	[SerializeField] public PricesSelf[] PricesUpSelf; //класс товаров для прокачки своего генератора

	public int[] PricesGen = new int[] { 10, 20, 30}; //ценники для покупки других генераторов

    

    void Start()
    {
    	gameManager = FindObjectOfType<GameManager>();
    	handGanerator = GameObject.FindGameObjectWithTag("Generator");
        
    }
    public void BuyUpSelf(int i)
    {
    	print(Mathf.FloorToInt(gameManager.Electricity));
    	if (gameManager.Electricity >= PricesUpSelf[i].Cost)
    	{
    		if (PricesUpSelf[i].Status)
    		{
    			gameManager.Electricity -= PricesUpSelf[i].Cost;
    			handGanerator.GetComponent<HandGenerator>().GeneratingSpeed += PricesUpSelf[i].Uprurn;
    			//gameManager.generators[0].ElectricityPerMoment += PricesUpSelf[i].Uprurn;
    			PricesUpSelf[i].Status = false;
    			//тут плашка, что продано
    		}
    	}
    	else
    	{
    		print("Где деньги, Лебовски?");
    	}

    }

    public void BuyGen(int i)
    {
    	print(Mathf.FloorToInt(gameManager.Electricity));
    	if (gameManager.Electricity >= PricesGen[i])
    	{
    		gameManager.Electricity -= PricesGen[i];
    		gameManager.autoGenerators[i].NumOfGenerators += 1;
    	}
    	else
    	{
    		print("Где деньги, Лебовски?");
    	}

    }
}

[System.Serializable]
public class PricesSelf
{
    public string NameOfBuy;
    public int Cost; //цена
    public float Uprurn; //значение увелечения
    public bool Status = true;
}
