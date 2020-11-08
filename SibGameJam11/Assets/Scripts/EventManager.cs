using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject MessegeField;
    public TextMeshProUGUI MessegeFieldText;

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
            if (!gameEvent.Executed && gameManager.ElectricityInTotal >= gameEvent.EnergyNeeded)
            {
                gameEvent.Executed = true;

                MessegeFieldText.text = gameEvent.Message;
                MessegeField.SetActive(true);

                switch (gameEvent.MyDebuffType)
                {
                    case GameEvent.DebuffType.DebuffAllGenerators:
                        gameManager.DebuffGeneratorsByTypes(gameEvent.DebuffTime);
                        break;
                    case GameEvent.DebuffType.TurnOffGeneratorType:
                        gameManager.TurnOffGeneratorsByTypes(gameEvent.TypesOfGenerators, gameEvent.DebuffTime);
                        break;
                    case GameEvent.DebuffType.SubsractElectrecity:
                        gameManager.SubstractElectricity(gameEvent.substractNum);
                        break;
                }
            }
        }
        if (MessegeField.active && Input.anyKeyDown)
        {
            MessegeField.SetActive(false);
        }
    }
}


[System.Serializable]
class GameEvent
{
    public string NameOfEvent;
    public float EnergyNeeded;
    public DebuffType MyDebuffType;
    [Header("SubstractType")]
    public float substractNum = 0;
    [Header("OtherTypes")]
    public string[] TypesOfGenerators;
    public float DebuffTime = 5;
    [Space, TextArea(5, 50)] public string Message = "";
    [HideInInspector] public bool Executed = false;

    public enum DebuffType
    {
        TurnOffGeneratorType,
        DebuffAllGenerators,
        SubsractElectrecity,
    }
}