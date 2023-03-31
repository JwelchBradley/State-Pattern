/*
 * (Jacob Welch)
 * (ProducingFactoryState)
 * (State Pattern)
 * (Description: A state for when the factory is actively producing stuff.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducingFactoryState : FactoryState
{
    #region Fields
    private float producingRate = 5;
    #endregion

    #region Functions
    public ProducingFactoryState(Factory factory) : base(factory)
    {

    }

    public override void GoToIdleState()
    {
        base.GoToIdleState();
    }

    public override void GoToProducingState()
    {
        Debug.Log("I am already here");
    }

    public override void GoToRepairingState()
    {
        base.GoToRepairingState();
    }

    public override void GoToBrokenState()
    {
        base.GoToBrokenState();
    }

    public override void UpdateTick()
    {
        Debug.Log("I am producing");
        factory.FactoryWorkLimit -= producingRate * Time.deltaTime;

        if(factory.FactoryWorkLimit == 0)
        {
            GoToBrokenState();
        }
    }

    public override void RefreshUI()
    {
        factory.RefreshUI(true, false, true);
    }
    #endregion
}
