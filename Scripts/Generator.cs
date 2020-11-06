using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	private int speed;
	public int lvl;
	private float factor;
    private GameObject GM;

    void Start()
    {
		switch (lvl)
		{
    		case 2:
        		speed = 2;
        		factor = 1f;
        		break;
    		case 3:
        		speed = 3;
        		factor = 0.5f;
        		break;
    		default:
        		speed = 1;
        		factor = 5f;
        		break;
        }
        GM = GameObject.FindGameObjectWithTag("GameManager");
        InvokeRepeating("Work", 1.0f, 1f * factor);
}

    
    void Update()
    {
    	transform.Rotate(0, 2.0f * speed, 0);
        
    }
    
    void Work()
    {
    	GM.GetComponent<GameManager>().money += 1;
        
    }
}
