using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipInformationText : MonoBehaviour {
   
    public TextMeshPro ShipVelocity, ShipRotation, HeliumRem, HeliumMax;

    ShipMovement shipMovement;
    ShipInformation shipInfo;
    ResourceInformation resourceInfo;

    void Start()
    {
        shipMovement = FindObjectOfType<ShipMovement>();
        shipInfo = FindObjectOfType<ShipInformation>();
        resourceInfo = FindObjectOfType<ResourceInformation>();
    }

    void Update()
    {
        ShipVelocity.text = Math.Round(shipMovement.Speed,3).ToString();
        ShipRotation.text = Math.Round(shipMovement.RotationSpeed,3).ToString();

        HeliumRem.text = Math.Round(resourceInfo.HeliumRemaining,0).ToString();
        HeliumMax.text = Math.Round(resourceInfo.HeliumMax,0).ToString();
    }
}
