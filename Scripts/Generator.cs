using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	private int speed = 1; //скорость с которой генераторы будут производить money
    private GameObject GM;
    private int profit = 1; // по сути булева переменная, но чот не работает при bool, поэтому int
    public GeneratorState state = GeneratorState.Normal; //изначальное состояние для генераторов

    public enum GeneratorState
    {
        Normal,
        Stay
    }

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager");
        InvokeRepeating("Work", 1.0f, 1f * speed);
	}
    void Update()
    {
    	transform.Rotate(0, 2.0f * speed, 0);
        
    }
    void FixedUpdate()
    {
    	switch (state)
        {
        	case GeneratorState.Stay:
                profit = 0;
                break;
            case GeneratorState.Normal:
                profit = 1;
                break;

        }

    }
    void Work()
    {
    	GM.GetComponent<GameManager>().TotalElectro += (GM.GetComponent<GameManager>().TotalGenerator / speed) * profit;
    	//гениальная формула, количество генераторов делиться на скорость, на нёё можно влиять с помощью бафов и умножается на скорость (булевый int)
        
    }

    void Fall()
    {
    	state = GeneratorState.Stay;
        
    }

    void LetsGo()
    {
    	state = GeneratorState.Normal;
        
    }

    void UpLVL()
    {
    	//Вероятно повышение лвл
    }
}
