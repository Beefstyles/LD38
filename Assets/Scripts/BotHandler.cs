using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BotType
{
    MiningBot, ArchBot, ExplorBot
};

public enum BotStatus
{
    TravellingToSurface, BotAction, ReturningToAtmosphere, WaitingForPickup, ReturnedToShip
};
public class BotHandler : MonoBehaviour {

    public TextMeshPro NumberMiningBotsTotalText, NumberMiningBotsActiveText, NumberMiningBotsPickupReqText, NumberExplorationBotsTotalText, NumberExplorationBotsActiveText, NumberExplorationBotsPickupReqText;
    public TextMeshPro NumberArchBotsTotalText, NumberArchBotsActiveText, NumberArchBotsPickupReqText;
    public TextMeshPro BotLine1, BotLine2, BotLine3, BotLine4, BotLine5, BotLine6, BotLine7, BotLine8, BotLine9, BotLine10, BotLine11, BotLine12;
    private Bot currentBot;
    ShipInformation ShipInfo;
    public int NoMiningBotsTotal;
    public int NoMiningBotsActive;
    public int NoMiningBotsPickupReq;
    public int NoExplorationBotsTotal;
    public int NoExplorationBotsActive;
    public int NoExplorationBotsPickupReq;
    public int NoArchBotsTotal;
    public int NoArchBotsActive;
    public int NoArchBotsPickupReq;
    private GameObject instantiatedBot;
    public Transform BotSpawnLocation;
    ResourceInformation resourceInfo;
    public bool SpawnSuccessful;
    private int currentBotNumber = 1;
    MessageHandler messageHandler;
    private string message;
    ArtifactHandler artifactHandler;
    private int MaxBots = 12;

    public GameObject MiningBot, ExplorBot, ArchBot;

    void Start()
    {
        ShipInfo = FindObjectOfType<ShipInformation>();
        messageHandler = FindObjectOfType<MessageHandler>();
        resourceInfo = FindObjectOfType<ResourceInformation>();
        artifactHandler = FindObjectOfType<ArtifactHandler>();
    }
    public void SpawnBot(BotType bt)
    {
        if((NoMiningBotsTotal + NoExplorationBotsTotal + NoArchBotsTotal) <= MaxBots)
        {

        }
        switch (bt)
        {
            case (BotType.MiningBot):
                if(NoMiningBotsTotal >= 1)
                {
                    NoMiningBotsTotal--;
                    NoMiningBotsActive++;
                    instantiatedBot = Instantiate(MiningBot, transform.position, transform.rotation) as GameObject;
                    currentBot = instantiatedBot.GetComponent<Bot>();
                    currentBot.BotNumber = currentBotNumber;
                    currentBotNumber++;
                    currentBot.BotLocation = ShipInfo.GridLocation;
                    SpawnSuccessful = true;
                    Debug.Log("Successfully spawned a mining bot");
                }
                else
                {
                    Debug.Log("Failed spawned a mining bot");
                    SpawnSuccessful = false;
                }
                break;
            case (BotType.ArchBot):
                if (NoArchBotsTotal >= 1)
                {
                    NoArchBotsTotal--;
                    NoArchBotsActive++;
                    instantiatedBot = Instantiate(ArchBot, transform.position, transform.rotation) as GameObject;
                    currentBot = instantiatedBot.GetComponent<Bot>();
                    currentBot.BotNumber = currentBotNumber;
                    currentBotNumber++;
                    currentBot.BotLocation = ShipInfo.GridLocation;
                    SpawnSuccessful = true;
                    Debug.Log("Successfully spawned a arch bot");
                }
                else
                {
                    Debug.Log("Failed spawned a arch bot");
                    SpawnSuccessful = false;
                }
                break;
            case (BotType.ExplorBot):
                if (NoExplorationBotsTotal >= 1)
                {
                    NoExplorationBotsTotal--;
                    NoExplorationBotsActive++;
                    instantiatedBot = Instantiate(ExplorBot, transform.position, transform.rotation) as GameObject;
                    currentBot = instantiatedBot.GetComponent<Bot>();
                    currentBot.BotNumber = currentBotNumber;
                    currentBotNumber++;
                    currentBot.BotLocation = ShipInfo.GridLocation;
                    SpawnSuccessful = true;
                    Debug.Log("Successfully spawned a explorer bot");
                }
                else
                {
                    Debug.Log("Failed spawned a explorer bot");
                    SpawnSuccessful = false;
                }
                break;
        }
    }

    void Update()
    {
        HandleTextUpdate();
    }

    void HandleTextUpdate()
    {
        NumberMiningBotsTotalText.text = NoMiningBotsTotal.ToString();
        NumberMiningBotsActiveText.text = NoMiningBotsActive.ToString();
        NumberMiningBotsPickupReqText.text = NoMiningBotsPickupReq.ToString();

        NumberExplorationBotsTotalText.text = NoExplorationBotsTotal.ToString();
        NumberExplorationBotsActiveText.text = NoExplorationBotsActive.ToString();
        NumberExplorationBotsPickupReqText.text = NoExplorationBotsPickupReq.ToString();

        NumberArchBotsTotalText.text = NoArchBotsTotal.ToString();
        NumberArchBotsActiveText.text = NoArchBotsActive.ToString();
        NumberArchBotsPickupReqText.text = NoArchBotsPickupReq.ToString();
    }

    public void BotReturned(BotType botType, Dictionary<string, int> MiningBotReturn, Dictionary<string, float> ExploreBotReturn, int NumberOfArtifact, string botLocation)
    {
        currentBotNumber--;
        switch (botType)
        {
            case BotType.MiningBot:
                NoMiningBotsTotal++;
                NoMiningBotsActive--;
                int miningReturn;
                message = "Mining Bot Returned from : " + botLocation + " with: ";
                MiningBotReturn.TryGetValue("Iron", out miningReturn);
                resourceInfo.TotalIron += miningReturn;
                message += "Iron: " + miningReturn + " ";
                MiningBotReturn.TryGetValue("Gold", out miningReturn);
                resourceInfo.TotalGold += miningReturn;
                message += "Gold: " + miningReturn + " ";
                MiningBotReturn.TryGetValue("Platinum", out miningReturn);
                resourceInfo.TotalPlatinum += miningReturn;
                message += "Platinum: " + miningReturn + " ";
                MiningBotReturn.TryGetValue("Carbon", out miningReturn);
                resourceInfo.TotalCarbon += miningReturn;
                message += "Carbon: " + miningReturn + " ";
                MiningBotReturn.TryGetValue("Helium3", out miningReturn);
                resourceInfo.HeliumRemaining += miningReturn;
                message += "Helium3: " + miningReturn + " ";
                messageHandler.ReceiveMessage(message);
                break;
            case BotType.ArchBot:
                NoArchBotsTotal++;
                NoArchBotsActive--;
                if(NumberOfArtifact >= 1)
                {
                    if (artifactHandler.CheckArtifact(botLocation))
                    {
                        message = "Returned Artifact from " + botLocation + " sucessfully. Only " + (4 - resourceInfo.NumberArtifacts) + " to go";
                    }
                    else
                    {
                        message = "Already taken Artifact from " + botLocation + ". Find the others";
                    }
                }
                break;
            case BotType.ExplorBot:
                NoExplorationBotsTotal++;
                NoExplorationBotsActive--;
                float explorerReturn;
                ExploreBotReturn.TryGetValue("Iron", out explorerReturn);
                message = "Explorer Bot Returned from " + botLocation + " with: " + explorerReturn + "% chance Iron, ";
                ExploreBotReturn.TryGetValue("Gold", out explorerReturn);
                message += explorerReturn + "% chance Gold, ";
                ExploreBotReturn.TryGetValue("Platinum", out explorerReturn);
                message += explorerReturn + "% chance Platinum, ";
                ExploreBotReturn.TryGetValue("Carbon", out explorerReturn);
                message += explorerReturn + "% chance Carbon, ";
                ExploreBotReturn.TryGetValue("Helium3", out explorerReturn);
                message += explorerReturn + "% chance Helium3 and ";
                ExploreBotReturn.TryGetValue("Artifact", out explorerReturn);
                message += explorerReturn + "% chance Artifact";
                messageHandler.ReceiveMessage(message);
                break;
            default:
                break;
        }
    }



}
