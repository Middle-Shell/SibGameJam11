using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public float Multiplier = 1.1f;

	private GameManager gameManager;
	private GameObject handGanerator;
	[SerializeField] public PricesSelf[] PricesUpSelf; //класс товаров для прокачки своего генератора

    [Header("Sound")]
    public AudioSource BuySound;

    void Start()
    {
    	gameManager = FindObjectOfType<GameManager>();
    	handGanerator = GameObject.FindGameObjectWithTag("Generator");
        
    }
    public void BuyUpSelf(int i, GameObject button)
    {
    	if (gameManager.Electricity >= PricesUpSelf[i].Cost)
        {
            gameManager.Electricity -= PricesUpSelf[i].Cost;
            PricesUpSelf[i].Status = false;
            gameManager.HandGeneratorUpgrade(PricesUpSelf[i].VisualHandGenerator);
            BuySound.Play();
            Destroy(button);
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
            generator.CostOfOne = Mathf.FloorToInt(generator.CostOfOne * Multiplier);
            generator.NumOfGenerators++;
            BuySound.Play();

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
    public GameObject VisualHandGenerator;
}
