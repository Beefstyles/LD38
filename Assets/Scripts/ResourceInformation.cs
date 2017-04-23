using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceInformation : MonoBehaviour {

    public int TotalIron, TotalGold, TotalPlatinum, TotalCarbon, NumberArtifacts;
    public float HeliumRemaining, HeliumMax;
    public TextMeshPro IronText, GoldText, PlatinumText, CarbonText, HeliumText, ArtifactText;
    public Dictionary<string, Dictionary<string, float>> GridRefChanceOfReturn = new Dictionary<string, Dictionary<string, float>>();
    
    void Update()
    {
        IronText.text = TotalIron.ToString();
        GoldText.text = TotalGold.ToString();
        PlatinumText.text = TotalPlatinum.ToString();
        CarbonText.text = TotalCarbon.ToString();
        HeliumText.text = HeliumRemaining.ToString();
        ArtifactText.text = NumberArtifacts.ToString();
    }
}
