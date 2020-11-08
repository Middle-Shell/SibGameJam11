using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject MessegeField;
    public TextMeshProUGUI MessegeFieldText;
    public AudioSource Sound;

    [SerializeField] private GameEvent[] events;
    private GameManager gameManager;

    GameEvent nextEvent;
    float nextElectricityNumber;

    private void Start()
    {
        if (events.Length > 0) nextEvent = events[0];
        nextElectricityNumber = 300;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void PlayEvent()
    {
        MessegeFieldText.text = nextEvent.Message;
        MessegeField.SetActive(true);
        Sound.Play();

        switch (nextEvent.MyDebuffType)
        {
            case GameEvent.DebuffType.TurnOffGeneratorType:
                gameManager.TurnOffGeneratorsByTypes(nextEvent.TypesOfGenerators, nextEvent.DebuffTime);
                break;

            case GameEvent.DebuffType.SubsractElectrecity:
                gameManager.SubstractElectricity(nextEvent.substractNum);
                break;

            case GameEvent.DebuffType.BuffAllgeneratorsTypes:
                foreach (string generator in nextEvent.TypesOfGenerators)
                {
                    gameManager.GetGeneratorByType(generator).Buff(nextEvent.DebuffTime);
                }
                break;

            case GameEvent.DebuffType.SubstractHalf:
                gameManager.SubstractElectricity(gameManager.Electricity / 2);
                break;
        }

        nextEvent = events[Random.Range(0, events.Length)];
        nextElectricityNumber = gameManager.ElectricityInTotal + Random.Range(500, 1500);
    }

    private void Update()
    {
        if (gameManager.ElectricityInTotal >= nextElectricityNumber)
        {
            PlayEvent();
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
    public DebuffType MyDebuffType;
    [Header("SubstractType")]
    public float substractNum = 0;
    [Header("OtherTypes")]
    public string[] TypesOfGenerators;
    public float DebuffTime = 5;
    [Space, TextArea(5, 50)] public string Message = "";

    public enum DebuffType
    {
        TurnOffGeneratorType,
        BuffAllgeneratorsTypes,
        SubsractElectrecity,
        SubstractHalf,
    }
}