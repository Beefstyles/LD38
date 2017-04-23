using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnShipLocation : MonoBehaviour {

    [HideInInspector]
    public string GridLocation;
    ShipInformation shipInformation;
    LightUpGridControl lgControl;
    public float ChanceOfIron, ChanceOfGold, ChanceOfPlatinum, ChanceOfCarbon, ChanceOfHelium3, ChanceOfArtifact;

    void Start()
    {
        GridLocation = gameObject.name;
        lgControl = FindObjectOfType<LightUpGridControl>();
        shipInformation = FindObjectOfType<ShipInformation>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Ship")
        {
            Debug.Log("You have entered " + GridLocation);
            shipInformation.SetGridLocation(GridLocation);
            lgControl.UpdateGridPosition(GridLocation, true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Ship")
        {
            //Debug.Log("You have exited " + GridLocation);
            lgControl.UpdateGridPosition(GridLocation, false);
        }
    }
}
