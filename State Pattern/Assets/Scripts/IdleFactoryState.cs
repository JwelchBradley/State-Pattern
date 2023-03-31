/*
 * (Jacob Welch)
 * (IdleFactoryState)
 * (State Pattern)
 * (Description: A state for when the factory is doing nothing on it's tick events.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFactoryState : FactoryState
{
    #region Functions
    public IdleFactoryState(Factory factory) : base(factory)
    {

    }

    public override void GoToIdleState()
    {
        Debug.Log("I am already here");
    }

    public override void GoToProducingState()
    {
        base.GoToProducingState();
    }

    public override void GoToRepairingState()
    {
        if(factory.FactoryWorkLimit != factory.maxFactoryWorkLimit)
        {
            base.GoToRepairingState();
        }
    }

    public override void GoToBrokenState()
    {
        base.GoToBrokenState();
    }

    public override void UpdateTick()
    {
        Debug.Log("I am doing nothing");
    }

    public override void RefreshUI()
    {
        factory.RefreshUI(false, true, factory.FactoryWorkLimit != factory.maxFactoryWorkLimit);
    }
    #endregion
}
