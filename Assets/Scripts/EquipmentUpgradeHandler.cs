using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipmentUpgradeHandler : MonoBehaviour {

    public TextMeshPro PassiveH3IronCostText, PassiveH3GoldCostText, PassiveH3PlatCostText, PassiveH3CarbonCostText;
    public TextMeshPro NewMiningBotIronCostText, NewMiningBotGoldCostText, NewMiningBotPlatCostText, NewMiningBotCarbonCostText;

    public int PassiveH3IronCost, PassiveH3GoldCost, PassiveH3PlatCost, PassiveH3CarbonCost;
    public int NewMiningBotIronCost, NewMiningBotGoldCost, NewMiningBotPlatCost, NewMiningBotCarbonCost;

    ResourceInformation resourceInfo;

    void Start()
    {
        resourceInfo = FindObjectOfType<ResourceInformation>();
    }

    public void ReceiveBuyingButton(BuyingOptions buyOption)
    {
        switch (buyOption)
        {
            case BuyingOptions.H3Unit:
                if (resourceInfo.TotalIron > PassiveH3IronCost && resourceInfo.TotalGold > PassiveH3GoldCost && resourceInfo.TotalPlatinum > PassiveH3PlatCost && resourceInfo.TotalCarbon > PassiveH3CarbonCost)
                {

                }
                    break;
            case BuyingOptions.NewMiningBot:
                break;
            case BuyingOptions.NewArchBot:
                break;
            case BuyingOptions.NewExplorBot:
                break;
            default:
                break;
        }
    }
}
