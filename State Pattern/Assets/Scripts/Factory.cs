/*
 * (Jacob Welch)
 * (Factory)
 * (State Pattern)
 * (Description: A factory that can be in states such as idle, producing, repairing, and broken.)
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    #region Fields
    // All of the states the factory can be in
    public BrokenFactoryState brokenFactoryState { get; private set; }
    public IdleFactoryState idleFactoryState { get; private set; }
    public ProducingFactoryState producingFactoryState { get; private set; }
    public RepairingFactoryState repairingFactoryState { get; private set; }

    /// <summary>
    /// The currently active state of the factory.
    /// </summary>
    private FactoryState currentFactoryState;

    /// <summary>
    /// The threshold for repairing after the factory has been broken.
    /// </summary>
    private float factoryWorkLimitRepairThreshold = 5;

    /// <summary>
    /// The max amount of work the factory can do before breaking or being repaired.
    /// </summary>
    public float maxFactoryWorkLimit { get; private set; }

    /// <summary>
    /// The current amount of work the factory can perform.
    /// </summary>
    private float factoryWorkLimit = 20;

    /// <summary>
    /// The current amount of work the factory can perform.
    /// </summary>
    public float FactoryWorkLimit 
    {
        get => factoryWorkLimit;
        set
        {
            factoryWorkLimit = value;
            factoryWorkLimit = Mathf.Clamp(factoryWorkLimit, 0, maxFactoryWorkLimit);

            if (factoryWorkLimitBar)
            {
                factoryWorkLimitBar.fillAmount = factoryWorkLimit / maxFactoryWorkLimit;
            }

            if (IsBroken && factoryWorkLimit > factoryWorkLimitRepairThreshold)
            {
                IsBroken = false;
            }
        }
    }

    // A bar for showing the current amount of work the factory can perform without breaking
    [SerializeField] private Image factoryWorkLimitBar;
    [SerializeField] private Image factoryWorkLimitThresholdBar;

    // Text displaying states and keybinds to change to them
    [SerializeField] private TextMeshProUGUI idleText;
    [SerializeField] private TextMeshProUGUI producingText;
    [SerializeField] private TextMeshProUGUI repairingText;
    [SerializeField] private TextMeshProUGUI currentStateText;

    // Images for displaying the current state of the factory
    [SerializeField] private Image stateSprite;
    [SerializeField] private Sprite producingSprite;
    [SerializeField] private Sprite repairingSprite;
    [SerializeField] private Sprite brokenSprite;

    /// <summary>
    /// Holds true if the factory is currenlty broken.
    /// </summary>
    public bool IsBroken { get; set; } = false;
    #endregion

    #region Functions
    /// <summary>
    /// Initializes all of the states.
    /// </summary>
    private void Awake()
    {
        brokenFactoryState = new BrokenFactoryState(this);
        idleFactoryState = new IdleFactoryState(this);
        producingFactoryState = new ProducingFactoryState(this);
        repairingFactoryState = new RepairingFactoryState(this);

        currentFactoryState = idleFactoryState;
        maxFactoryWorkLimit = factoryWorkLimit;

        if(factoryWorkLimitThresholdBar)
        factoryWorkLimitThresholdBar.fillAmount = factoryWorkLimitRepairThreshold / maxFactoryWorkLimit;
    }

    /// <summary>
    /// Gets users inputs and preforms states acitons.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentFactoryState.GoToIdleState();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentFactoryState.GoToProducingState();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentFactoryState.GoToRepairingState();
        }

        currentFactoryState.UpdateTick();
        currentFactoryState.RefreshUI();
    }

    /// <summary>
    /// Sets the current state to be a new one.
    /// </summary>
    /// <param name="factoryState"></param>
    public void SetState(FactoryState factoryState)
    {
        currentFactoryState = factoryState;

        if (currentStateText)
        {
            SetCurrentStateText();
        }
    }

    /// <summary>
    /// Sets the text and images that display the current state.
    /// </summary>
    private void SetCurrentStateText()
    {
        string currentStateString = "Current State: ";

        switch (currentFactoryState)
        {
            case IdleFactoryState:
                currentStateString += "Idle";
                stateSprite.color = Color.clear;
                break;
            case BrokenFactoryState:
                currentStateString += "Broken";
                stateSprite.color = Color.white;
                stateSprite.sprite = brokenSprite;
                break;
            case ProducingFactoryState:
                currentStateString += "Producing";
                stateSprite.color = Color.white;
                stateSprite.sprite = producingSprite;
                break;
            case RepairingFactoryState:
                currentStateString += "Repairing";
                stateSprite.color = Color.white;
                stateSprite.sprite = repairingSprite;
                break;
            default:
                currentStateString += "Idle";
                break;
        }

        currentStateText.text = currentStateString;
    }

    /// <summary>
    /// Refreshes the text for what states the user cna currently transition to.
    /// </summary>
    /// <param name="canIdle"></param>
    /// <param name="canProduce"></param>
    /// <param name="canRepair"></param>
    public void RefreshUI(bool canIdle, bool canProduce, bool canRepair)
    {
        if (idleText)
        {
            idleText.color = canIdle ? Color.white : Color.gray;
        }

        if (producingText)
        {
            producingText.color = canProduce ? Color.white : Color.gray;
        }

        if (repairingText)
        {
            repairingText.color = canRepair ? Color.white : Color.gray;
        }
    }
    #endregion
}
