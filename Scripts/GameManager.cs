using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float Electricity = 0;
    public float summ;
    [SerializeField] Generators[] types;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Work", 1.0f, 1f);
        
    }

    void Work()
    {
        summ = 0;

        for (int i = 0; i < 4; i++)
        {
            //Наверное здесь должна быть проверка на работу типа генератора
            summ += types[i].Count * types[i].ProfitInSeconds;
        }
        Electricity += summ;
        //Наверное здесь должна быть проверка на работу типа

    }
}
[System.Serializable]
class Generators
{
    public float Count;
    public float ProfitInSeconds;
    public bool IsWork = true;
    public string name = "";

}
