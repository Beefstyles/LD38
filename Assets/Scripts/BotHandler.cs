using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BotType
{
    MiningBot, ArchBot, ExplorBot
};

public enum BotStatus
{
    TravellingToSurface, Mining, Exploring, Prospecting, ReturningToAtmosphere, WaitingForPickup
};
public class BotHandlerText
{
    public Text NumberMiningBotsTotalText, NumberMiningBotsActiveText, NumberMiningBotsPickupReqText, NumberExplorationBotsTotalText, NumberExplorationBotsActiveText, NumberExplorationBotsPickupReqText;
    public Text NumberArchBotsTotalText, NumberArchBotsActiveText, NumberArchBotsPickupReqText;
}
public class BotHandler : MonoBehaviour {


    public int NumberMiningBotsTotal;
    public int NumberMiningBotsActive;
    public int NumberMiningBotsPickupReq;
    public int NumberExplorationBotsTotal;
    public int NumberExplorationBotsActive;
    public int NumberExplorationBotsPickupReq;
    public int NumberArchBotsTotal;
    public int NumberArchBotsActive;
    public int NumberArchBotsPickupReq;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
