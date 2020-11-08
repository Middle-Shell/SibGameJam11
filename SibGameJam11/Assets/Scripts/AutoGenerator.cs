using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class AutoGenerator : MonoBehaviour
{
    public string TypeOfGenerator;
    public int NumOfGenerators; //цена
    public int CostOfOne; //цена
    public float DefaultElectricityPerMoment = 1; //значение увелечения
    /*[HideInInspector]*/public float CurrentElectricityPerMoment = 1;
    public bool IsWorking = true;
    [Space, Header("Visuals")]
    public UnityArmatureComponent VisualGenerator;
    public Placement myPlacement;

    private bool IsBuffed = false;
    private bool IsDebuffed = false;

    private void Start()
    {
        CurrentElectricityPerMoment = DefaultElectricityPerMoment;
    }

    private void Update()
    {
        if (NumOfGenerators == 0)
        {
            VisualGenerator.gameObject.SetActive(false);
            myPlacement.TurnOffElectricity();
        }
        else
        {
            VisualGenerator.gameObject.SetActive(true);
            myPlacement.TurnOnElectricity();
        }

        if (IsWorking)
        {
            if (VisualGenerator.animation.lastAnimationName != "0")
            {
                VisualGenerator.animation.Play("0");
            }
            myPlacement.TurnOnElectricity();
        }
        else
        {
            if (VisualGenerator.animation.lastAnimationName != "1")
            {
                VisualGenerator.animation.Play("1");
            }
            myPlacement.TurnOffElectricity();
        }
    }

    #region Buff:

    public void Buff()
    {
        if (!IsBuffed)
        {
            StartCoroutine(RemoveBuff());
        }
    }

    IEnumerator RemoveBuff()
    {
        IsBuffed = true;
        CurrentElectricityPerMoment *= 2;

        yield return new WaitForSeconds(.5f);

        IsBuffed = false;
        if (!IsDebuffed)
        {
            CurrentElectricityPerMoment = DefaultElectricityPerMoment;
        }
        else
        {
            CurrentElectricityPerMoment = DefaultElectricityPerMoment / 2;
        }
    }

    #endregion

    #region Debuff:

    public void Debuff(float debuffTime)
    {
        if (!IsDebuffed)
        {
            StartCoroutine(RemoveDebuff(debuffTime));
        }
    }

    IEnumerator RemoveDebuff(float debuffTime)
    {
        //IsDebuffed = true;
        //CurrentElectricityPerMoment /= 2;
        IsWorking = false;

        yield return new WaitForSeconds(debuffTime);

        IsWorking = true;
        //IsDebuffed = false;
        //CurrentElectricityPerMoment = DefaultElectricityPerMoment;
    }

    #endregion
}