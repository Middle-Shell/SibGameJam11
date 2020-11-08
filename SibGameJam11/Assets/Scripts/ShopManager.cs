using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

	private GameManager gameManager;
	private GameObject handGanerator;
	[SerializeField] public PricesSelf[] PricesUpSelf; //класс товаров для прокачки своего генератора

    

    void Start()
    {
    	gameManager = FindObjectOfType<GameManager>();
    	handGanerator = GameObject.FindGameObjectWithTag("Generator");
        
    }
    public void BuyUpSelf(int i)
    {
    	if (gameManager.Electricity >= PricesUpSelf[i].Cost)
    	{
    		if (PricesUpSelf[i].Status)
    		{
    			gameManager.Electricity -= PricesUpSelf[i].Cost;
    			PricesUpSelf[i].Status = false;
    		}
    	}
    	else
    	{
    		print("Где деньги, Лебовски?");
    	}

    }

    public void BuyGen(string generatorType)
    {
        AutoGenerator generator = gameManager.GetGeneratorByType(generatorType);

        if (gameManager.Electricity >= generator.CostOfOne)
    	{
    		gameManager.Electricity -= generator.CostOfOne;
            generator.NumOfGenerators++;
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
    public bool Status = true;
}
