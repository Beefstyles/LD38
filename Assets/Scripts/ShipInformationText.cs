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

    void Start()
    {
        shipMovement = FindObjectOfType<ShipMovement>();
        shipInfo = FindObjectOfType<ShipInformation>();
    }

    void Update()
    {
        ShipVelocity.text = Math.Round(shipMovement.Speed,3).ToString();
        ShipRotation.text = Math.Round(shipMovement.RotationSpeed,3).ToString();

        HeliumRem.text = Math.Round(shipInfo.HeliumRemaining,0).ToString();
        HeliumMax.text = Math.Round(shipInfo.HeliumMax,0).ToString();
    }
}
