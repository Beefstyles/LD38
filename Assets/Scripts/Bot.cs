using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bot : MonoBehaviour {

    public BotType BotType;
    public int BotNumber;
    public BotStatus BotStatus;
    public float Timer;
    public float TimeToSurface, TimeForAction, TimeToReturn;

	void Start () {
        Timer = 0;
        BotStatus = BotStatus.TravellingToSurface;
	}
	

	void Update ()
    {
        if(BotStatus != BotStatus.WaitingForPickup)
        {
            Timer += Time.deltaTime;
            UpdateStatus();
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
