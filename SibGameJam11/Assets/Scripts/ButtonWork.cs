using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonWork : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI Title;
	private GameObject Shop;
	public int IndexOfType;
	public Button Button;

    // Start is called before the first frame update
    public void Start ()
    {
    	Button Button = this.gameObject.GetComponent<Button>();
    	Button.onClick.AddListener(TaskOnClick);
    	Shop = GameObject.FindGameObjectWithTag("Shop");
    	//Title.text = "ХУЕТА";
        
    }

    void TaskOnClick()
    {
		Shop.GetComponent<ShopManager>().BuyGen(IndexOfType);
		Title.text = "ХУЕТА";	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
