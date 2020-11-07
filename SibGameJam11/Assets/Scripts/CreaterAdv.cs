using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterAdv : MonoBehaviour
{

	public GameObject Prefabs; 
	private GameObject Advertisment; 
    // Start is called before the first frame update
    void Start()
    {
    	for (int i = 0; i < 3; i++)
        {
        	Advertisment = Instantiate(Prefabs, new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform );
            Advertisment.GetComponent<ButtonWork>().IndexOfType = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
