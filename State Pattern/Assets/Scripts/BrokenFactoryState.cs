/*
 * (Jacob Welch)
 * (BrokenFactoryState)
 * (State Pattern)
 * (Description: A state for when the factory is broken.)
 */
using UnityEngine;

public class BrokenFactoryState : FactoryState
{
    #region Functions
    public BrokenFactoryState(Factory factory) : base(factory)
    {
        
    }

    public override void GoToIdleState()
    {
        Debug.Log("Can not idle while the factory is broken");
    }

    public override void GoToProducingState()
    {
        Debug.Log("Can not start producing while the factory is broken");
    }

    public override void GoToRepairingState()
    {
        base.GoToRepairingState();
    }

    public override void GoToBrokenState()
    {
        Debug.Log("I am already here");
    }

    public override void UpdateTick()
    {
        Debug.Log("I am broken");
    }

    public override void RefreshUI()
    {
        factory.RefreshUI(false, false, true);
    }
    #endregion
}
