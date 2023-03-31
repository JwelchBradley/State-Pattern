/*
 * (Jacob Welch)
 * (RepairingFactoryState)
 * (State Pattern)
 * (Description: A state for when the factory is repairing itself.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairingFactoryState : FactoryState
{
    #region Fields
    private float reparingRate = 5;
    #endregion

    #region Functions
    public RepairingFactoryState(Factory factory) : base(factory)
    {

    }

    public override void GoToIdleState()
    {
        if (!factory.IsBroken)
        {
            base.GoToIdleState();
        }
    }

    public override void GoToProducingState()
    {
        if (!factory.IsBroken)
        {
            base.GoToProducingState();
        }
    }

    public override void GoToRepairingState()
    {
        Debug.Log("I am already here");
    }

    public override void GoToBrokenState()
    {
        base.GoToBrokenState();
    }

    public override void UpdateTick()
    {
        Debug.Log("I am repairing");
        factory.FactoryWorkLimit += reparingRate * Time.deltaTime;

        if(factory.FactoryWorkLimit == factory.maxFactoryWorkLimit)
        {
            GoToIdleState();
        }
    }

    public override void RefreshUI()
    {
        factory.RefreshUI(!factory.IsBroken, !factory.IsBroken, false);
    }
    #endregion
}
