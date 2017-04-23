using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bot : MonoBehaviour {

    public BotType BotType;
    public int BotNumber;
    public BotStatus BotStatus;
    public float Timer;
    public float TimeToSurface, TimeForAction, TimeToReturn;
    public string BotLocation;
    private string statusText;
    BotHandler botHandler;
    public float timeRemaining;
    ShipInformation shipInfo;
    public int AmountOfIron, AmountOfGold, AmountOfPlatinum, AmountOfCarbon, AmountOfHelium, NumberOfArtifact;

	void Start () {
        Timer = 0;
        botHandler = FindObjectOfType<BotHandler>();
        shipInfo = FindObjectOfType<ShipInformation>();
        BotStatus = BotStatus.TravellingToSurface;
        timeRemaining = TimeToSurface - Timer;
        if(BotLocation == shipInfo.GridLocation)
        {
            Debug.Log("Test?");
        }
    }
	

	void Update ()
    {
        if(BotStatus != BotStatus.WaitingForPickup)
        {
            Timer += Time.deltaTime;
        }
        UpdateStatus();
        statusText = BotNumber + " " + BotType + " " + BotStatus + " " + BotLocation + " " + Math.Round(timeRemaining, 2).ToString();
        switch (BotNumber)
        {
            case (1):
                botHandler.BotLine1.text = statusText;
                break;
            case (2):
                botHandler.BotLine2.text = statusText;
                break;
            case (3):
                botHandler.BotLine3.text = statusText;
                break;
            case (4):
                botHandler.BotLine4.text = statusText;
                break;
            case (5):
                botHandler.BotLine5.text = statusText;
                break;
            case (6):
                botHandler.BotLine6.text = statusText;
                break;
        }
    }

    void UpdateStatus()
    {
        switch (BotStatus)
        {
            case (BotStatus.TravellingToSurface):
                timeRemaining = TimeToSurface - Timer;
                if (Timer >= TimeToSurface)
                {
                    Timer = 0;
                    BotStatus = BotStatus.BotAction;
                }
                break;
            case (BotStatus.BotAction):
                timeRemaining = TimeForAction - Timer;
                if (Timer >= TimeForAction)
                {
                    Timer = 0;
                    BotStatus = BotStatus.ReturningToAtmosphere;
                }
                break;
            case (BotStatus.ReturningToAtmosphere):
                timeRemaining = TimeToReturn - Timer;
                if (Timer >= TimeToReturn)
                {
                    timeRemaining = 0F;
                    Timer = 0;
                    BotStatus = BotStatus.WaitingForPickup;
                }
                break;
            case (BotStatus.WaitingForPickup):
                if(BotLocation == shipInfo.GridLocation)
                {
                    BotStatus = BotStatus.ReturnedToShip;

                }
                break;
        }
    }
}
