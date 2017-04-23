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
    TravellingToSurface, BotAction, ReturningToAtmosphere, WaitingForPickup
};
public class BotHandler : MonoBehaviour {

    public TextMeshPro NumberMiningBotsTotalText, NumberMiningBotsActiveText, NumberMiningBotsPickupReqText, NumberExplorationBotsTotalText, NumberExplorationBotsActiveText, NumberExplorationBotsPickupReqText;
    public TextMeshPro NumberArchBotsTotalText, NumberArchBotsActiveText, NumberArchBotsPickupReqText;

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

    public GameObject MiningBot, ExplorBot, ArchBot;


    public void SpawnBot(BotType bt)
    {
        switch (bt)
        {
            case (BotType.MiningBot):
                if(NoMiningBotsTotal > 1)
                {
                    NoMiningBotsTotal--;
                    NoMiningBotsActive++;
                    instantiatedBot = Instantiate(MiningBot, BotSpawnLocation) as GameObject;
                    instantiatedBot.GetComponent<Bot>().BotNumber = 1;
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
}
