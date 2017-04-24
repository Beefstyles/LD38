using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ResourceInformation : MonoBehaviour {

    public int TotalIron, TotalGold, TotalPlatinum, TotalCarbon, NumberArtifacts;
    public int NumberPassiveH3Units;
    public float HeliumRemaining, HeliumMax;
    public TextMeshPro IronText, GoldText, PlatinumText, CarbonText, HeliumText, ArtifactText;
    public Dictionary<string, Dictionary<string, float>> GridRefChanceOfReturn = new Dictionary<string, Dictionary<string, float>>();
    
    void Update()
    {
        IronText.text = TotalIron.ToString();
        GoldText.text = TotalGold.ToString();
        PlatinumText.text = TotalPlatinum.ToString();
        CarbonText.text = TotalCarbon.ToString();
        HeliumText.text = Math.Round(HeliumRemaining,0).ToString();
        ArtifactText.text = NumberArtifacts.ToString();
    }

    IEnumerator IncreaseH3Passively()
    {
        yield return new WaitForSeconds(1F);
        if(HeliumRemaining < HeliumMax)
        {
            HeliumRemaining += (NumberPassiveH3Units * 3);
        }

    }
}
