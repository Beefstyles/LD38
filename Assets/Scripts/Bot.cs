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
    public Dictionary<string, int> MiningBotResourceReturn = new Dictionary<string, int>();
    public Dictionary<string, float> ExploreBotResourceReturn = new Dictionary<string, float>();
    public int NumberOfArtifact;
    ResourceInformation resourceInfo;
    int randomNumber;
    public int IronReturn, GoldReturn, PlatinumReturn, CarbonReturn, HeliumReturn, ArtifactReturn;


	void Start () {
        MiningBotResourceReturn.Add("Iron", 0);
        MiningBotResourceReturn.Add("Gold", 0);
        MiningBotResourceReturn.Add("Platinum", 0);
        MiningBotResourceReturn.Add("Carbon", 0);
        MiningBotResourceReturn.Add("Helium3", 0);

        ExploreBotResourceReturn.Add("Iron", 0F);
        ExploreBotResourceReturn.Add("Gold", 0F);
        ExploreBotResourceReturn.Add("Platinum", 0F);
        ExploreBotResourceReturn.Add("Carbon", 0F);
        ExploreBotResourceReturn.Add("Helium3", 0F);
        ExploreBotResourceReturn.Add("Artifact", 0F);

        resourceInfo = FindObjectOfType<ResourceInformation>();
        Timer = 0;
        botHandler = FindObjectOfType<BotHandler>();
        shipInfo = FindObjectOfType<ShipInformation>();
        BotStatus = BotStatus.TravellingToSurface;
        timeRemaining = TimeToSurface - Timer;


    }
	

	void Update ()
    {
        if(BotStatus != BotStatus.WaitingForPickup || BotStatus != BotStatus.ReturnedToShip)
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
            case (7):
                botHandler.BotLine7.text = statusText;
                break;
            case (8):
                botHandler.BotLine8.text = statusText;
                break;
            case (9):
                botHandler.BotLine9.text = statusText;
                break;
            case (10):
                botHandler.BotLine10.text = statusText;
                break;
            case (11):
                botHandler.BotLine11.text = statusText;
                break;
            case (12):
                botHandler.BotLine12.text = statusText;
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
                switch (BotType)
                {
                    case BotType.MiningBot:
                        botHandler.NoMiningBotsPickupReq++;
                        break;
                    case BotType.ArchBot:
                        botHandler.NoArchBotsPickupReq++;
                        break;
                    case BotType.ExplorBot:
                        botHandler.NoExplorationBotsPickupReq++;
                        break;
                }
                if(BotLocation == shipInfo.GridLocation)
                {
                    BotStatus = BotStatus.ReturnedToShip;
                    ExploreBotResourceReturn = resourceInfo.GridRefChanceOfReturn[BotLocation];
                    switch (BotType)
                    {
                        case BotType.MiningBot:
                            botHandler.NoMiningBotsPickupReq--;
                            randomNumber = returnRandomNumber();

                            if(randomNumber <= (ExploreBotResourceReturn["Iron"] / 10))
                            {
                                MiningBotResourceReturn["Iron"] = IronReturn;
                            }
                            else
                            {
                                MiningBotResourceReturn["Iron"] = 0;
                            }
                            randomNumber = returnRandomNumber();
                            if (randomNumber <= (ExploreBotResourceReturn["Gold"] / 10))
                            {
                                MiningBotResourceReturn["Gold"] = GoldReturn;
                            }
                            else
                            {
                                MiningBotResourceReturn["Gold"] = 0;
                            }
                            randomNumber = returnRandomNumber();
                            if (randomNumber <= (ExploreBotResourceReturn["Platinum"] / 10))
                            {
                                MiningBotResourceReturn["Platinum"] = PlatinumReturn;
                            }
                            else
                            {
                                MiningBotResourceReturn["Platinum"] = 0;
                            }
                            randomNumber = returnRandomNumber();
                            if (randomNumber <= (ExploreBotResourceReturn["Carbon"] / 10))
                            {
                                MiningBotResourceReturn["Carbon"] = CarbonReturn;
                            }
                            else
                            {
                                MiningBotResourceReturn["Carbon"] = 0;
                            }
                            randomNumber = returnRandomNumber();
                            if (randomNumber <= (ExploreBotResourceReturn["Helium3"] / 10))
                            {
                                MiningBotResourceReturn["Helium3"] = HeliumReturn;
                            }
                            else
                            {
                                MiningBotResourceReturn["Helium3"] = 0;
                            }
                            break;
                        case BotType.ArchBot:
                            randomNumber = returnRandomNumber();
                            if (randomNumber <= (ExploreBotResourceReturn["Artifact"] / 10))
                            {
                                NumberOfArtifact = ArtifactReturn;
                            }
                            break;
                        case BotType.ExplorBot:
                            //Shouldn't need to do anything
                            break;
                        default:
                            break;
                    }
                    botHandler.BotReturned(BotType, MiningBotResourceReturn, ExploreBotResourceReturn, NumberOfArtifact, BotLocation);
                }
                break;
            case BotStatus.ReturnedToShip:
                switch (BotType)
                {
                    case BotType.MiningBot:
                        if(botHandler.NoMiningBotsPickupReq > 0)
                        {
                            botHandler.NoMiningBotsPickupReq--;
                        }

                        break;
                    case BotType.ArchBot:
                        if (botHandler.NoArchBotsPickupReq > 0)
                        {
                            botHandler.NoArchBotsPickupReq--;
                        }
                        break;
                    case BotType.ExplorBot:
                        if (botHandler.NoExplorationBotsPickupReq > 0)
                        {
                            botHandler.NoExplorationBotsPickupReq--;
                        }
                        break;
                }
                break;
        }
    }

    private int returnRandomNumber()
    {
        int rand = UnityEngine.Random.Range(1, 10);
        return rand;
    }
}
