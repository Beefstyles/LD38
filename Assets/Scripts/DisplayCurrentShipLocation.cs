using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrentShipLocation : MonoBehaviour {

    public TextMeshPro ShipLocation;
    ShipInformation shipInfo;

	void Start ()
    {
        shipInfo = FindObjectOfType<ShipInformation>();
    }
	
	void Update () {
        ShipLocation.text = shipInfo.GridLocation;
    }
}
