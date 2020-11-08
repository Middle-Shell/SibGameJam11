using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonWorker : MonoBehaviour
{
	public TextMeshProUGUI Title;
	public TextMeshProUGUI PricePerformance;
	public string GeneratorType;

    private ShopManager Shop;
    private CreaterAdv myCreaterAdv;

    public void Start ()
    {
        Shop = FindObjectOfType<ShopManager>();
        myCreaterAdv = FindObjectOfType<CreaterAdv>();
    }

    public void TaskOnClick()
    {
		Shop.BuyGen(GeneratorType);
        myCreaterAdv.UpdateInfo();
    }
}
