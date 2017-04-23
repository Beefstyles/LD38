using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipmentUpgradeHandler : MonoBehaviour {

    public TextMeshPro PassiveH3IronCostText, PassiveH3GoldCostText, PassiveH3PlatCostText, PassiveH3CarbonCostText;
    public TextMeshPro NewMiningBotIronCostText, NewMiningBotGoldCostText, NewMiningBotPlatCostText, NewMiningBotCarbonCostText;

    public int PassiveH3IronCost, PassiveH3GoldCost, PassiveH3PlatCost, PassiveH3CarbonCost;
    public int NewMiningBotIronCost, NewMiningBotGoldCost, NewMiningBotPlatCost, NewMiningBotCarbonCost;
    public int NewArchIronCost, NewArchBotGoldCost, NewArchBotPlatCost, NewArchBotCarbonCost;
    public int NewExplorBotIronCost, NewExplorBotGoldCost, NewExplorBotPlatCost, NewExplorBotCarbonCost;

    ResourceInformation resourceInfo;
    BotHandler botHandler;

    void Start()
    {
        resourceInfo = FindObjectOfType<ResourceInformation>();
        botHandler = FindObjectOfType<BotHandler>();
    }

    public void ReceiveBuyingButton(BuyingOptions buyOption)
    {
        switch (buyOption)
        {
            case BuyingOptions.H3Unit:
                if (resourceInfo.TotalIron > PassiveH3IronCost && resourceInfo.TotalGold > PassiveH3GoldCost && resourceInfo.TotalPlatinum > PassiveH3PlatCost && resourceInfo.TotalCarbon > PassiveH3CarbonCost)
                {
                    resourceInfo.NumberPassiveH3Units++;
                }
                else
                {
                    BuyingFailed();
                }
                    break;
            case BuyingOptions.NewMiningBot:
                if (resourceInfo.TotalIron > NewMiningBotIronCost && resourceInfo.TotalGold > NewMiningBotGoldCost && resourceInfo.TotalPlatinum > NewMiningBotPlatCost && resourceInfo.TotalCarbon > NewMiningBotCarbonCost)
                {
                    botHandler.NoMiningBotsTotal++;
                }
                else
                {
                    BuyingFailed();
                }
                break;
            case BuyingOptions.NewArchBot:
                if (resourceInfo.TotalIron > NewArchIronCost && resourceInfo.TotalGold > NewArchBotGoldCost && resourceInfo.TotalPlatinum > NewArchBotPlatCost && resourceInfo.TotalCarbon > NewArchBotCarbonCost)
                {
                    botHandler.NoArchBotsTotal++;
                }
                else
                {
                    BuyingFailed();
                }
                break;
            case BuyingOptions.NewExplorBot:
                if (resourceInfo.TotalIron > NewExplorBotIronCost && resourceInfo.TotalGold > NewExplorBotGoldCost && resourceInfo.TotalPlatinum > NewExplorBotPlatCost && resourceInfo.TotalCarbon > NewExplorBotCarbonCost)
                {
                    botHandler.NoExplorationBotsTotal++;
                }
                else
                {
                    BuyingFailed();
                }
                break;
            default:
                break;
        }
    }

    public void BuyingFailed()
    {

    }
}
