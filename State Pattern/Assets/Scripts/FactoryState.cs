/*
 * (Jacob Welch)
 * (FactoryState)
 * (State Pattern)
 * (Description: A base abstract class for all factory states.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryState
{
    #region Fields
    /// <summary>
    /// The factory that this state applies to.
    /// </summary>
    protected Factory factory;
    #endregion

    #region Functions
    /// <summary>
    /// Initializes the state with the factory that it applies to.
    /// </summary>
    /// <param name="factory"></param>
    public FactoryState(Factory factory)
    {
        this.factory = factory;
    }

    /// <summary>
    /// Performs an event for the state every tick.
    /// </summary>
    public abstract void UpdateTick();

    /// <summary>
    /// Transitions to the idle state if possible.
    /// </summary>
    public virtual void GoToIdleState()
    {
        factory.SetState(factory.idleFactoryState);
    }

    /// <summary>
    /// Transitions to the producing state if possible.
    /// </summary>
    public virtual void GoToProducingState()
    {
        factory.SetState(factory.producingFactoryState);
    }

    /// <summary>
    /// Transitions to the repairing state if possible.
    /// </summary>
    public virtual void GoToRepairingState()
    {
        factory.SetState(factory.repairingFactoryState);
    }

    /// <summary>
    /// Transitions to the broken state if possible.
    /// </summary>
    public virtual void GoToBrokenState()
    {
        factory.IsBroken = true;
        factory.SetState(factory.brokenFactoryState);
    }

    /// <summary>
    /// Refreshes the UI that displays what transitions can be made.
    /// </summary>
    public abstract void RefreshUI();
    #endregion
}
