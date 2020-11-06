using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameEvent[] events;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        foreach (GameEvent gameEvent in events)
        {
            if (!gameEvent.Executed && gameManager.Electricity >= gameEvent.EnergyNeeded)
            {
                gameEvent.Executed = true;
                gameManager.DebuffGeneratorOfType(gameEvent.TypeOfGenerators, gameEvent.DebuffTime);
            }
        }
    }
}


[System.Serializable]
class GameEvent
{
    public float EnergyNeeded;
    public string NameOfEvent;
    public string TypeOfGenerators;
    public float DebuffTime = 5;
    [HideInInspector] public bool Executed = false;
}