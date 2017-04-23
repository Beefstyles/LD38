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
    public TextMeshPro BotLine1, BotLine2, BotLine3, BotLine4, BotLine5, BotLine6;
    private Bot currentBot;
    ShipInformation ShipInfo;
    public int NoMiningBotsTotal;
    public int NoMiningBotsActive;
    public int NumberMiningBotsPickupReq;
    public int NumberExplorationBotsTotal;
    public int NumberExplorationBotsActive;
    public int NumberExplorationBotsPickupReq;
    public int NumberArchBotsTotal;
    public int NumberArchBotsActive;
    public int NumberArchBotsPickupReq;
    private GameObject instantiatedBot;
    public Transform BotSpawnLocation;
    public bool SpawnSuccessful;
    private int currentBotNumber = 1;

    public GameObject MiningBot, ExplorBot, ArchBot;

    void Start()
    {
        ShipInfo = FindObjectOfType<ShipInformation>();
    }
    public void SpawnBot(BotType bt)
    {
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
        NumberMiningBotsPickupReqText.text = NumberMiningBotsPickupReq.ToString();

        NumberExplorationBotsTotalText.text = NumberExplorationBotsTotal.ToString();
        NumberExplorationBotsActiveText.text = NumberExplorationBotsActive.ToString();
        NumberExplorationBotsPickupReqText.text = NumberExplorationBotsPickupReq.ToString();

        NumberArchBotsTotalText.text = NumberArchBotsTotal.ToString();
        NumberArchBotsActiveText.text = NumberArchBotsActive.ToString();
        NumberArchBotsPickupReqText.text = NumberArchBotsPickupReq.ToString();
    }

    public void BotReturned(BotType botType)
    {

    }


}
