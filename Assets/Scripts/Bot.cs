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

	void Start () {
        Timer = 0;
        botHandler = FindObjectOfType<BotHandler>();
        BotStatus = BotStatus.TravellingToSurface;
	}
	

	void Update ()
    {
        if(BotStatus != BotStatus.WaitingForPickup)
        {
            Timer += Time.deltaTime;
            UpdateStatus();
        }
        statusText = BotNumber + " " + BotType + " " + BotStatus + " " + BotLocation + " " + Math.Round(Timer, 2).ToString();
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
                if (Timer >= TimeToSurface)
                {
                    BotStatus = BotStatus.BotAction;
                }
                break;
            case (BotStatus.BotAction):
                if (Timer >= TimeForAction)
                {
                    BotStatus = BotStatus.ReturningToAtmosphere;
                }
                break;
            case (BotStatus.ReturningToAtmosphere):
                if (Timer >= TimeToReturn)
                {
                    BotStatus = BotStatus.WaitingForPickup;
                }
                break;
        }
    }
}
